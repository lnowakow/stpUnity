using UnityEngine;

namespace Menu
{
    public class MenuRealTeleopSlaveState : MenuBaseState
    {
        public override void EnterState(MenuStateManager menu, Cursor cursor)
        {
            Debug.Log("Menu In Real Teleop Slave State");
            menu.currentStateString = "RealTeleopSlaveState";
            menu.transform.root.GetComponent<ConsoleStateManager>().SwitchState(
                menu.transform.root.GetComponent<ConsoleStateManager>().ConsoleState[menu.currentStateString]);
        }

        public override void UpdateState(MenuStateManager menu, Cursor cursor)
        {
            //Debug.Log("Menu " + menu.name + ": in Spectator State.");
            //Debug.Log("The Menu should be visible");
        }
        
    }
}