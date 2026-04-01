using Godot;

namespace nobody_modules.Module;
public enum EffectState
{
	STOPPED,
	RUNNING,
	PAUSED,
	UNLOAD
}

public struct SpriteData
{
    public int Frame { get; set; }
    public Color Modulate { get; set; }
    public Vector2 Scale { get; set; }
}

[GlobalClass]
[Icon("res://addons/nobody_modules/Resource/char_module.png")]
public partial class CharacterModule : Node
{
	public string SeachSpriteName { get; set; } = "Sprite2D";
	public string SeachAnimatedSpriteName { get; set; } = "AnimatedSprite2D";

	[Export]
    public float EffectTimer { get; set; }
	[Export]
	public float IncrementAmount { get; set; }
	[Export]
	public bool IgnoreInitialingWarning { get; set; }
	[Export]
	public bool LoopEffect { get; set; } = true;
	
	private EffectState _effectState = EffectState.UNLOAD;

	private Timer _effect_timer = null;
	private SpriteData _original_sprite2D;
	private SpriteData _original_animatedSprite2D;

	protected Sprite2D _sprite;
	protected AnimatedSprite2D _animatedSprite;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
	{
		Node parent = this.GetParent();
		if(parent == null)
		{
			GD.PushError("The module haven't a parent. The module will not initialize!");
			return;
		}

		_sprite = parent.GetNodeOrNull<Sprite2D>(SeachSpriteName);
		_animatedSprite = parent.GetNodeOrNull<AnimatedSprite2D>(SeachAnimatedSpriteName);

		_effect_timer = new Timer() { OneShot = !LoopEffect, WaitTime = EffectTimer };
		_effect_timer.Timeout += _EndEffect;
        this.GetTree().Root.CallDeferred(MethodName.AddChild, _effect_timer);

        _LoadedEffect();
        if (IgnoreInitialingWarning) return;
        if (_sprite == null) GD.PushWarning("This Parent: "+parent.Name+". Has no Sprite to load!");
		if (_animatedSprite == null) GD.PushWarning("This Parent: " + parent.Name + ". Has no Animated Sprite to load!");
    }

	public void Start()
	{
		if(_effectState == EffectState.PAUSED)
		{
			_effectState = EffectState.RUNNING;
			_effect_timer.Paused = false;
			return;
		}

		_RunningEffect();
		_effect_timer.Start();
    }

	public void Pause()
	{
		_PausingEffect();
        _effect_timer.Stop();
    }

	public void Stop()
	{
        _EndEffect(); 
		_effect_timer.Stop();
    }

	protected virtual void _RunningEffect()
	{
		_original_sprite2D = ExtractSpriteData(_sprite);
        _original_animatedSprite2D = ExtractSpriteData(_animatedSprite);

        _effectState = EffectState.RUNNING;
    }

    protected virtual void _PausingEffect()
	{
        PushSpriteData(_original_sprite2D, _sprite);
        PushSpriteData(_original_animatedSprite2D, _animatedSprite);
        _effectState = EffectState.PAUSED;
    }

    protected virtual void _EndEffect()
    {
        PushSpriteData(_original_sprite2D, _sprite);
        PushSpriteData(_original_animatedSprite2D, _animatedSprite);
        _effectState = EffectState.STOPPED;
		
    }

    protected virtual void _LoadedEffect()
	{
		_effectState = EffectState.STOPPED;
    }

	private SpriteData ExtractSpriteData(object sprite)
	{
		SpriteData sd = new SpriteData();
        if (sprite is Sprite2D sSprite)
        {
            sd.Frame = sSprite.Frame;
            sd.Modulate = sSprite.Modulate;
            sd.Scale = sSprite.Scale;
        }
        else if (sprite is AnimatedSprite2D aSprite)
        {
            sd.Frame = aSprite.Frame;
            sd.Modulate = aSprite.Modulate;
            sd.Scale = aSprite.Scale;
        }
		return sd;
    }
    private void PushSpriteData(SpriteData spriteData, object sprite)
	{
        if (sprite is Sprite2D sSprite)
		{
			sSprite.Frame  = spriteData.Frame;
			sSprite.Modulate = spriteData.Modulate;
			sSprite.Scale = spriteData.Scale;
		}
		else if(sprite is AnimatedSprite2D aSprite)
		{	
			aSprite.Frame  = spriteData.Frame;
			aSprite.Modulate = spriteData.Modulate;
			aSprite.Scale = spriteData.Scale;
        }
    }

	public EffectState EffectState { get => _effectState; }
}
