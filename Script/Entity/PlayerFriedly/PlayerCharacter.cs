using Godot;
using nobody_modules.Module.Effect;
using projetogodotvampcast.Script.CombatWeapon;
using projetogodotvampcast.Script.CombatWeapon.WP;
using System.Collections.Generic;

namespace projetogodotvampcast.Script.Entity.PlayerFriendly;
public delegate void PlayerVitalStatus();
public enum PlayerState
{
    IDLE,
    WALKING,
    JUMPING,
    FALLING,
    DASHING,
    ATTACKING,
    DIED
}

public partial class PlayerCharacter : LivingCharacter
{

    private Dictionary<string, Timer> playerTimers = new Dictionary<string, Timer>()
    {
        { "Dash", new Timer() { WaitTime = 0.5f, OneShot = true, Autostart = false }},
        { "Hitted", new Timer() { WaitTime = 1f, OneShot = true, Autostart = false } }
    };

    private PlayerState state = PlayerState.IDLE;
    public PlayerState CurrentState { get => state; }

    private Weapon currentWeapon;
    public Weapon CurrentWeaponEquipped { get => currentWeapon; }

    private Sprite2D _Sprite;
    private FadeInOut _module_fade;
    private PlayerPhysicalHit _physical_hit;

    public override void _Ready()
    {
        currentWeapon = new VampireFists();

        life = MaxLife;
        health = MaxHealth;
        mana = MaxMana;

        foreach (Timer t in playerTimers.Values) GetTree().CurrentScene.CallDeferred("add_child", t);
        playerTimers["Hitted"].Timeout += () => { _module_fade?.Stop(); };

        _module_fade = GetNode<FadeInOut>("FadeInOut");
        _physical_hit = GetNode<PlayerPhysicalHit>("PhysicalHit");

        _Sprite = GetNode<Sprite2D>("Sprite2D");
    }

    public override void _Process(double delta)
    {
        base._Process(delta);

        if (Input.IsActionJustPressed("action")) ActionOn();
    }

    public override void _PhysicsProcess(double delta)
    {
        Vector2 velocity = Velocity;
        Vector2 inputVector = Input.GetVector("left", "right", "up", "down");
        velocity.X = inputVector.X * Speed;

        if(inputVector.X != 0) _Sprite.FlipH = inputVector.X < 0;
        if (!IsOnFloor())
        {
            velocity.Y += (GetGravity() * (float)delta).Y;
        }
        else
        {
            if(Input.IsActionJustPressed("jump"))
            {
                velocity.Y = JumpForce;
            }
        }

        Velocity = velocity;
        MoveAndSlide();
    }

    public override void TakeDamage(int damage)
    {
        if (!playerTimers["Hitted"].IsStopped()) return;
        base.TakeDamage(damage);

        playerTimers["Hitted"].Start();
        _module_fade?.Start();
    }

    private void ActionOn()
    {
        if(!_physical_hit.IsHitting) PhysicalAttack();
    }
    private void PhysicalAttack()
    {
        //GD.Print("Attacando!!");
        _physical_hit.StartHitBox();
    }

    public bool CanHit { get => playerTimers["Hitted"].IsStopped(); }
}