using projetogodotvampcast.Script.WCurse;
using System.Collections.Generic;

namespace projetogodotvampcast.Script.CombatWeapon;
public abstract class Weapon
{
    private List<Curse> curseBody = new List<Curse>();

    public void CurseWeapon(Curse curse)
    {
        curseBody.Add(curse);
    }

    public int Level { get; set; }

    public string Name { get; set; }
    public string Description { get; set; }

    public float Weight { get; set; }
    public double Price { get; set; } = 0;
}
