using UnityEngine;

public abstract class MenuBaseState
{
    public abstract void EnterState(MenuStateManager menu, string option);
    public abstract  void UpdateState(MenuStateManager menu, string option);
}
