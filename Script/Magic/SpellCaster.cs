using Godot;
using projetogodotvampcast.Script.Magic.SpellMaterial;
using projetogodotvampcast.Script.Magic.Spells.spells_mechanism;

namespace projetogodotvampcast.Script.Magic;

[GlobalClass]
public partial class SpellCaster : Node2D
{
	[Export] public MaterialSpell SpellToCast {get; set;}

	[Export] public float SpellMaterializationTime { get; set; } = 2.0f;
	[Export] public float CasterMagicDamage {get; set;} = 1f;
	[Export] public SpellDirection CastDirection {get; set;} = SpellDirection.LEFT;
	[Export] public bool DestroyWhenCast {get; set; } = true;

	private Marker2D _castLocation = null;
	private Timer _castTimer = null;

	public override void _Ready()
	{
		_castLocation = GetNode<Marker2D>("CastLocation");
		_castTimer = GetNode<Timer>("CastTimer");

		_castTimer.Timeout += _on_CastTimer_timeout;
	}

	private void _on_CastTimer_timeout()
	{
		mk_phy spellInst = SpellToCast.SpellMechanism.Instantiate<mk_phy>();
		spellInst.Spell = SpellToCast;
		spellInst.Direction = CastDirection;

		GetTree().CurrentScene.CallDeferred("add_child", spellInst);
		if(DestroyWhenCast) return;

		_castTimer.Start();
	}
}
