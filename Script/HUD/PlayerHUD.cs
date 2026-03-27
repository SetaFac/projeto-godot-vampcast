using Godot;

public partial class PlayerHUD : Control
{
	private CanvasLayer _CanvasLayer;

    private Control _HealthInfo;
	private ProgressBar __HealthBar;

	private Control _ManaInfo;
	private ProgressBar __ManaBar;

	private PlayerCharacter FocusCharacter;

    public override void _Ready()
	{
		_CanvasLayer = GetNode<CanvasLayer>("CanvasLayer");

        _HealthInfo = _CanvasLayer.GetNode<Control>("HealthInfo");
		__HealthBar = _HealthInfo.GetNode<ProgressBar>("HealthBar");

        _ManaInfo = _CanvasLayer.GetNode<Control>("ManaInfo");
		__ManaBar = _ManaInfo.GetNode<ProgressBar>("ManaBar");

        FocusCharacter = GetTree().CurrentScene.GetNode<PlayerCharacter>("PlayerCharacter");
		if (FocusCharacter != null)
		{
			FocusCharacter.OnHealthChange += __on_PlayerHealthChange;
			FocusCharacter.OnManaChange += __on_PlayerManaChange;
        }

		__HealthBar.MaxValue = FocusCharacter.MaxHealth;
		__HealthBar.Value = FocusCharacter.Health;
        __ManaBar.MaxValue = FocusCharacter.MaxMana;
		__ManaBar.Value = FocusCharacter.Mana;
    }

	private void __on_PlayerHealthChange()
	{
		__HealthBar.Value = FocusCharacter.Health;
    }

	private void __on_PlayerManaChange()
	{
		__ManaBar.Value = FocusCharacter.Health;
    }
}
