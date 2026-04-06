using Godot;
using System;

namespace projetogodotvampcast.Script.Entity;

public delegate void CharacterVitalStatus();

[GlobalClass]
public partial class LivingCharacter : CharacterBody2D
{
    public event CharacterVitalStatus OnHealthChange;
    public event CharacterVitalStatus OnLifeChange;
    public event CharacterVitalStatus OnManaChange;

    public string DisplayName { get; set; } = "Living Character";

    public int MaxHealth { get; set; } = 100;
    public int MaxMana { get; set; } = 50;
    public int MaxLife { get; set; } = 1;

    protected int life = 0;
    protected int health = 0;
    protected int mana = 0;

    public float Speed { get; set; } = 200f;
    public float JumpForce { get; set; } = -250f;

    public virtual void TakeDamage(int damage)
    {
        Health -= damage;
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
}