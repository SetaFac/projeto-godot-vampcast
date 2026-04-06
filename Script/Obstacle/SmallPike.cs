using Godot;
using projetogodotvampcast.Script.Entity.PlayerFriendly;

namespace projetogodotvampcast.Script.Obstacle;
public partial class SmallPike : Area2D
{
	public int Damage { get; set; } = 20;
	
	public override void _Ready()
	{
		BodyEntered += __on_SmallPike_body_entered;
    }

	private void __on_SmallPike_body_entered(Node2D body)
	{
		if (body is PlayerCharacter player)
		{
			player.TakeDamage(Damage);
		}
    }
}
