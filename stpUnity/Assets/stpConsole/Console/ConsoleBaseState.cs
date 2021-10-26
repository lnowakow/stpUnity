using UnityEngine;

public abstract class ConsoleBaseState
{
    public abstract void EnterState(ConsoleStateManager console);
    public abstract  void UpdateState(ConsoleStateManager console);
    public abstract void ExitState(ConsoleStateManager console);
}
