using Godot;
using System;

namespace projetogodotvampcast.Script.Entity.Enemy;
public partial class Dummy : LivingCharacter
{
	public Dummy()
	{
		DisplayName = "Dummy";
		Health = 100;
		Mana = 50;
		Life = 1;
    }
}
