using Godot;
using projetogodotvampcast.Script.Entity;

namespace projetogodotvampcast.Script.HUD;
public partial class EntityInfo : Control
{
	private ProgressBar _health_bar;
	private ProgressBar _mana_bar;

	private LivingCharacter _character;

	public override void _Ready()
	{
		Node parent = this.GetParent();
		if (parent is LivingCharacter lChar)
		{
            _character = lChar;
            _health_bar = this.GetNode<ProgressBar>("HealthBar");
			_mana_bar = this.GetNode<ProgressBar>("ManaBar");
			lChar.OnHealthChange += UpdateHealthGUI;
			lChar.OnManaChange += UpdateManaGUI;

			UpdateHealthGUI();
			UpdateManaGUI();
        }
		else
		{
			GD.PrintErr("EntityInfo must be a child of a LivingCharacter.");
			this.QueueFree();
		}
    }

	private void UpdateHealthGUI()
	{
		float calc_value = (float)_character.Health / _character.MaxHealth;
        calc_value *= (int)_health_bar.MaxValue;
        _health_bar.Value = calc_value;
    }

	private void UpdateManaGUI()
	{
		float calc_value = (float)_character.Mana / _character.MaxMana;
		calc_value *= (int)_mana_bar.MaxValue;
        _mana_bar.Value = calc_value;
    }
}
