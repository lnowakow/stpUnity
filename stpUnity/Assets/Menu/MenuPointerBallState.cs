using System.Collections.Generic;
using UnityEngine;

namespace Menu
{
    public class MenuPointerBallState : MenuBaseState
    {
        public override void EnterState(MenuStateManager menu, Cursor cursor)
        {
            menu.menu_options["sub_options"] = new [] {4, 5, 6, 7, 8, 9};
            menu.currentStateString = "PointerBallState";
            menu.gameObject.transform.parent.GetComponent<ConsoleStateManager>().SwitchState(
                menu.gameObject.transform.parent.GetComponent<ConsoleStateManager>().ConsoleState[menu.currentStateString]);
        }

        public override void UpdateState(MenuStateManager menu, Cursor cursor)
        {
            //Debug.Log("Menu " + menu.name + ": in Spectator State.");
            //Debug.Log("The Menu should be visible");

        }
    }
}
        