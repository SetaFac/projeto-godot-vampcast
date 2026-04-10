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

public abstract class Spell
{
    public string Name { get; protected set; }
    
    public ElementalType Element { get; protected set; }
    public float ManaCost { get; protected set; }
    public float Cooldown { get; protected set; }
    public float Coolup { get; protected set; }
   
    public int Power { get; protected set; }
    public int Level { get; protected set; } = 1;

    public virtual void Cast()
    {
        // Logic to create the spell's visual and physical representation in the game world
    }
}
