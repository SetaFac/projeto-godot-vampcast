using Godot;
using projetogodotvampcast.Script.CombatWeapon;
using projetogodotvampcast.Script.Entity;
using projetogodotvampcast.Script.Entity.PlayerFriendly;
using System.Collections.Generic;

public partial class PlayerPhysicalHit : Area2D
{
	private PlayerCharacter _character;
	private List<LivingCharacter> _body_debounce = new List<LivingCharacter>();

	//Temporary Timer!!
	private Timer hit_timer = new Timer() { Autostart = false, WaitTime = 0.5, OneShot = true };

	public override void _Ready()
	{
		Node parent = this.GetParent();
		if (parent is PlayerCharacter player)
		{
			_character = player;
			this.BodyEntered += OnBodyEntered;
		}
		else
		{
			GD.PrintErr("PlayerPhysicalHit must be a child of PlayerCharacter!");
			this.QueueFree();
		}
		GetTree().Root.CallDeferred(MethodName.AddChild, hit_timer);
		hit_timer.Timeout += () =>
		{
			_body_debounce.Clear();
			this.Monitoring = false;
		};
    }

	private void OnBodyEntered(Node body)
	{
		
		if (body is LivingCharacter enemy)
		{
			if (_body_debounce.Find(x => x == enemy) != null) return;
			_body_debounce.Add(enemy);

            Weapon playerW = _character.CurrentWeaponEquipped;
			if (playerW == null) return;

			if(playerW is IPhysicalW phyW) enemy.TakeDamage(phyW.PhysicalDamage);
		}
    }

    //Temporary method, will be called by PlayerCharacter when attacking
    public void StartHitBox()
	{
		this.Monitoring = true;
		hit_timer.Start();
    }

	public bool IsHitting => this.Monitoring;
}
