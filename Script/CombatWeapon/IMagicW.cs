namespace projetogodotvampcast.Script.CombatWeapon;
public interface IMagicW
{
    public int ManaCost { get; set; }
    public int HealthCost { get; set; }

    public int MagicDamage { get; }
}