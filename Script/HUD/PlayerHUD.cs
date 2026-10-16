using Godot;
using projetogodotvampcast.Script.Entity.PlayerFriendly;

namespace projetogodotvampcast.Script.HUD;

public partial class PlayerHUD : Control
{
	private CanvasLayer _CanvasLayer;

    private Control _HealthInfo;
	private ProgressBar _HealthBar;

	private Control _ManaInfo;
	private ProgressBar _ManaBar;

	private PlayerCharacter FocusCharacter;

    public override void _Ready()
	{
		_CanvasLayer = GetNode<CanvasLayer>("CanvasLayer");

        _HealthInfo = _CanvasLayer.GetNode<Control>("HealthInfo");
		_HealthBar = _HealthInfo.GetNode<ProgressBar>("HealthBar");

        _ManaInfo = _CanvasLayer.GetNode<Control>("ManaInfo");
		_ManaBar = _ManaInfo.GetNode<ProgressBar>("ManaBar");

        FocusCharacter = GetTree().CurrentScene.GetNode<PlayerCharacter>("PlayerCharacter");
		if (FocusCharacter != null)
		{
			FocusCharacter.OnHealthChange += __on_PlayerHealthChange;
			FocusCharacter.OnManaChange += __on_PlayerManaChange;
        }

		_HealthBar.MaxValue = FocusCharacter.MaxHealth;
		_HealthBar.Value = FocusCharacter.Health;
        _ManaBar.MaxValue = FocusCharacter.MaxMana;
		_ManaBar.Value = FocusCharacter.Mana;
    }

	private void __on_PlayerHealthChange()
	{
		_HealthBar.Value = FocusCharacter.Health;
    }

	private void __on_PlayerManaChange()
	{
		_ManaBar.Value = FocusCharacter.Mana;
    }
}
