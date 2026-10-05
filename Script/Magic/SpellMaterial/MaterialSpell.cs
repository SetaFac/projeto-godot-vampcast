using Godot;

namespace projetogodotvampcast.Script.Magic.SpellMaterial;

[GlobalClass]
public partial class MaterialSpell : Spell
{
    [Export] public int MagicalDamage { get; set; }
    [Export] public float MaterializeCastDelay { get; set; }
    [Export] public float KeepMaterializeTime { get; set; }
    
    [Export] public float MagicalSpeed { get; set; }
}