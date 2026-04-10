using Godot;
using projetogodotvampcast.Script.Magic.SpellMaterial;

namespace projetogodotvampcast.Script.Magic.Spells;

public class FireBall : Spell, IMaterializeSpell
{
    public FireBall()
    {
        Name = "Fire Ball";
        Element = ElementalType.FIRE;
        ManaCost = 40f;
        Cooldown = 2f;
        Coolup = 0.5f;
        Power = 50;
    }
    //FAZER O CASTER!!!!!!!
    public int MagicalDamage { get; } = 50;
    public float MagicalSpeed => 200.0f;
    
    public float MaterializeCastDelay => 1.2f;
    public float MaterializeTime { get; } = 30f;

    public void Materialize(Node where, Vector2 position)
    {
        
    }
}
