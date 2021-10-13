using UnityEngine;

namespace Menu
{
    public class MenuRealTeleopSlaveState : MenuBaseState
    {
        public override void EnterState(MenuStateManager menu, Cursor cursor)
        {
            Debug.Log("Menu In Real Teleop Slave State");
            menu.gameObject.transform.parent.GetComponent<ConsoleStateManager>().SwitchState(
                menu.gameObject.transform.parent.GetComponent<ConsoleStateManager>().console_states[menu.currentState]);
        }

        public override void UpdateState(MenuStateManager menu, Cursor cursor)
        {
            //Debug.Log("Menu " + menu.name + ": in Spectator State.");
            //Debug.Log("The Menu should be visible");
        }
        
    }
}