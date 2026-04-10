using Godot;

namespace projetogodotvampcast.Script.Magic.SpellMaterial;
public interface IMaterializeSpell
{
    public int MagicalDamage { get; }
    public float MaterializeCastDelay { get; }
    public float MaterializeTime { get; }
    
    public float MagicalSpeed { get; }

    public void Materialize(Node where, Vector2 position);
}
