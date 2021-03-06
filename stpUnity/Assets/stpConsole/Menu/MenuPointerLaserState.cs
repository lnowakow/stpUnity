
using UnityEngine;

namespace Menu
{
    public class MenuPointerLaserState : MenuBaseState
    {
        public override void EnterState(MenuStateManager menu, Cursor cursor)
        {
            Debug.Log("In Pointer Laser State");
            menu.currentStateString = "PointerLaserState";
            menu.transform.root.parent.GetComponent<ConsoleStateManager>().SwitchState(
                menu.transform.root.GetComponent<ConsoleStateManager>().ConsoleState[menu.currentStateString]);
        }

        public override void UpdateState(MenuStateManager menu, Cursor cursor)
        {
            //Debug.Log("Menu " + menu.name + ": in Spectator State.");
            //Debug.Log("The Menu should be visible");
        }
    }
}