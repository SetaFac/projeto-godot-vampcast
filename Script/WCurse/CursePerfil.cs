namespace projetogodotvampcast.Script.WCurse;
public abstract class CursePerfil
{
    private string name;
    private int level;
    private bool isAlive;

    public CursePerfil(string name, int level, bool isAlive)
    {
        this.name = name;
        this.level = level;
        this.isAlive = isAlive;
    }

    public string Name { get => name; }
    public int Level { get => level; }
    public bool IsAlive { get => isAlive; }

    public string Description { get; set; }
    public double Price { get; set; }
    public float ManaOscilation { get; set; }
    public bool IsActive { get; set; }
}
