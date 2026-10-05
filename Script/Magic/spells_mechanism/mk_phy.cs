using Godot;
using projetogodotvampcast.Script.Magic.SpellMaterial;

namespace projetogodotvampcast.Script.Magic.Spells.spells_mechanism;
public partial class mk_phy : Area2D
{
    [Export] public MaterialSpell Spell {get; set;}
    [Export] public int Damage { get; set; } = 50;
    [Export] public float Speed { get; set; } = 200f;
	[Export] public SpellDirection Direction { get; set; } = SpellDirection.LEFT;

    public Node NoDamageCaster { get; set; }

    public override void _Ready()
    {
        base._Ready();
        if(Spell != null)
        {
            Damage = Spell.MagicalDamage;
            Speed = Spell.MagicalSpeed;
        }
    }
}