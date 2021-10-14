using UnityEngine;

public abstract class MenuBaseState
{
    public abstract void EnterState(MenuStateManager menu, Cursor cursor);
    public abstract void UpdateState(MenuStateManager menu, Cursor cursor);
}
