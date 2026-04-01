using Godot;

namespace nobody_modules.Module.Effect;

[GlobalClass]
[Icon("res://addons/nobody_modules/Resource/char_module.png")]
public partial class FadeInOut : CharacterModule
{
    enum EffectTarget { SPRITE, ANIMATED_SPRITE };
    private EffectTarget _target;

    private Color _original_color;
    private float _increment_value = 0f;

    public override void _Ready()
    {
        base._Ready();
        _target = _sprite != null ? EffectTarget.SPRITE : EffectTarget.ANIMATED_SPRITE;
        _original_color = _sprite != null ? _sprite.Modulate : _animatedSprite.Modulate;
    }

    public override void _Process(double delta)
    {
        base._Process(delta);
        if (EffectState == EffectState.RUNNING) RunEffect();
    }

    private void RunEffect()
    {
        if(_original_color.A >= 1)
        {
            _increment_value = -IncrementAmount;
        }
        else if(_original_color.A <= 0)
        {
            _increment_value = IncrementAmount;
        }

        _original_color.A += _increment_value;
        if (_sprite != null) _sprite.Modulate = _original_color;
        else if(_animatedSprite != null) _animatedSprite.Modulate = _original_color;
    }
}
