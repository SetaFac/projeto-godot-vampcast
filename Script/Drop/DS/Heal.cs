using Godot;
using projetogodotvampcast.Script.Drop;
using projetogodotvampcast.Script.Entity;

[GlobalClass]
public partial class Heal : Dropable
{
    [Export]
    public int HealAmount { get; set; } = 10;

    public override void _CharacterPicking(Node other)
    {
        base._CharacterPicking(other);
        if(other is LivingCharacter livChar)
        {
            livChar.Health += HealAmount;
            QueueFree();
        }
    }
}
