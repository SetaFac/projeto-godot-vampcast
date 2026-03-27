using Godot;
using System;
using System.Collections.Generic;

public delegate void PlayerVitalStatus();

public enum PlayerState
{
    Idle,
    Walking,
    Jumping,
    Falling,
    Dashing,
    Attacking,
    Died
}

public partial class PlayerCharacter : CharacterBody2D
{
    public event PlayerVitalStatus OnHealthChange;
    public event PlayerVitalStatus OnLifeChange;
    public event PlayerVitalStatus OnManaChange;

    private Dictionary<string, Timer> playerTimers = new Dictionary<string, Timer>()
    {
        { "Dash", new Timer() { WaitTime = 0.5f, OneShot = true, Autostart = false }},
        { "Hitted", new Timer() { WaitTime = 1f, OneShot = true, Autostart = false } }
    };

    private string DisplayName { get; set; } = "Player";

    private float Speed { get; set; } = 200f;
    private float JumpForce { get; set; } = -250f;

    private PlayerState state = PlayerState.Idle;
    public PlayerState CurrentState { get => state; }

    public int MaxLife { get; set; } = 1;
    public  int MaxHealth { get; set; } = 100;
    public int MaxMana { get; set; } = 50;

    private int life = 0;
    private int health = 0;
    private int mana = 0;


    private Sprite2D _Sprite;

    public override void _Ready()
    {
        life = MaxLife;
        health = MaxHealth;
        mana = MaxMana;

        _Sprite = GetNode<Sprite2D>("Sprite2D");
        foreach (Timer t in playerTimers.Values) GetTree().CurrentScene.CallDeferred("add_child", t);
    }

    public override void _PhysicsProcess(double delta)
    {
        Vector2 velocity = Velocity;
        Vector2 inputVector = Input.GetVector("left", "right", "up", "down");
        velocity.X = inputVector.X * Speed;

        if(inputVector.X != 0) _Sprite.FlipH = inputVector.X < 0;
        if (!IsOnFloor())
        {
            velocity.Y += (GetGravity() * (float)delta).Y;
        }
        else
        {
            if(Input.IsActionJustPressed("jump"))
            {
                velocity.Y = JumpForce;
            }
        }

        Velocity = velocity;
        MoveAndSlide();
    }

    public void TakeDamage(int damage)
    {
        if (!playerTimers["Hitted"].IsStopped()) return;

        Health -= damage;
        playerTimers["Hitted"].Start();
    }

    public int Health
    {
        get => health;
        set
        {
            health = Math.Clamp(value, 0, MaxHealth);
            OnHealthChange?.Invoke();
        }
    }

    public int Life
    {
        get => life;
        set
        {
            life = Math.Clamp(value, 0, MaxLife);
            OnLifeChange?.Invoke();
        }
    }

    public int Mana
    {
        get => mana;
        set
        {
            mana = Math.Clamp(value, 0, MaxMana);
            OnManaChange?.Invoke();
        }
    }

    public bool CanHit { get => playerTimers["Hitted"].IsStopped(); }
}