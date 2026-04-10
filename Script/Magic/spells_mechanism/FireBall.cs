using Godot;
using projetogodotvampcast.Script.Entity;

namespace projetogodotvampcast.Script.Magic.Spells.spells_mechanism;
public partial class FireBall : Area2D
{
    [Export]
	public int Damage { get; set; } = 50;
    [Export]
	public float Speed { get; set; } = 200f;

	public int Direction { get; set; } = 1;
    public Node Caster { get; set; }

    public override void _PhysicsProcess(double delta)
    {
        base._PhysicsProcess(delta);
        Position += new Vector2(Speed * Direction * (float)delta, 0);
    }

    private void _on_body_entered(Node body)
    {
        if (body is CollisionObject2D collisionedObject)
        {
            if (body == Caster) return;
            if(collisionedObject is LivingCharacter character) character.TakeDamage(Damage);
            QueueFree();
        }
    }
}
