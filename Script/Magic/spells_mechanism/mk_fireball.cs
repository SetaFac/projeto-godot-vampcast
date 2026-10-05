using Godot;
using projetogodotvampcast.Script.Entity;

namespace projetogodotvampcast.Script.Magic.Spells.spells_mechanism;
public partial class mk_fireball : mk_phy
{
    public override void _Process(double delta)
    {
        base._Process(delta);
        BodyEntered += _on_body_entered;
    }

    public override void _PhysicsProcess(double delta)
    {
        base._PhysicsProcess(delta);
        Position += new Vector2(Speed * (int)Direction * (float)delta, 0);
    }

    private void _on_body_entered(Node body)
    {
        if (body is CollisionObject2D collisionedObject)
        {
            if (body == NoDamageCaster) return;
            if(collisionedObject is LivingCharacter character) character.TakeDamage(Damage);
            QueueFree();
        }
    }
}