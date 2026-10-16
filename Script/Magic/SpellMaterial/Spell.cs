using Godot;

namespace projetogodotvampcast.Script.Magic.SpellMaterial;
public enum ElementalType
{
    FIRE,
    WATER,
    EARTH,
    AIR,
    LIGHTNING,
    ICE,
    DARKNESS,
    HOLY
}

public enum SpellDirection
{
    LEFT = -1,
    RIGHT = 1
}

[GlobalClass]
public partial class Spell : Resource
{
    [Export] public PackedScene SpellMechanism {get; set;}

    [Export] public ElementalType Element { get; set; }
    [Export] public int ManaCost { get; set; }
    [Export] public float Cooldown { get; set; }
    [Export] public float Coolup { get; set; }
   
    [Export] public int Power { get; set; } = 5;
    [Export] public int Level { get; set; } = 1;
}
