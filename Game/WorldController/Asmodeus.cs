using Godot;
using projetogodotvampcast.Script.Magic;
using projetogodotvampcast.Script.Magic.SpellMaterial;

namespace projetogodotvampcast.Game.WorldController;

[GlobalClass]
public partial class Asmodeus : Node
{
    [Export] public PackedScene PreferredCastSystem {get; set;}

    public void CastMaterialSpell(MaterialSpell spell, Vector2 position)
    {
        SpellCaster spellCaster = PreferredCastSystem.Instantiate<SpellCaster>();
        spellCaster.SpellToCast = spell;
        spellCaster.Position = position;

        GetTree().CurrentScene.CallDeferred("add_child", spellCaster);
    }
}