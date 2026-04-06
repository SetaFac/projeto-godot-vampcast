namespace projetogodotvampcast.Script.CombatWeapon.WP;

public class VampireFists : Weapon, IPhysicalW
{
    public VampireFists()
    {
        Name = "Vampire Fists";
        Description = "A pair of mystical fists that drain the life force of enemies with each strike.";
        Weight = 0.4f;
    }

    public int PhysicalRange => 5;
    public int PhysicalDamage => 10;
}