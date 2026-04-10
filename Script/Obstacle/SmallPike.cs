using Godot;
using projetogodotvampcast.Script.Entity.PlayerFriendly;

namespace projetogodotvampcast.Script.Obstacle;
public partial class SmallPike : StaticBody2D
{
	private const double _defaultFallSpeedToDamage = 200.0;
	private Area2D _damageArea = null;

	[Export]
	public int Damage { get; set; } = 20;
	
	public override void _Ready()
	{
		_damageArea = GetNode<Area2D>("DamageArea");
        _damageArea.BodyEntered += __on_SmallPike_body_entered;
    }

	private void __on_SmallPike_body_entered(Node2D body)
	{
		if (body is PlayerCharacter player)
		{
			GD.Print($"Velocidade Y Do player: {player.Velocity.Y}");
			if(player.Velocity.Y >= _defaultFallSpeedToDamage) player.TakeDamage(Damage);
        }
    }
}
