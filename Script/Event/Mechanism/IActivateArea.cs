namespace projetogodotvampcast.Script.Event.Mechanism;

public delegate void MechanismAction();

public interface IActivateArea
{
    public event MechanismAction OnActivate;
    public void Activate();
}