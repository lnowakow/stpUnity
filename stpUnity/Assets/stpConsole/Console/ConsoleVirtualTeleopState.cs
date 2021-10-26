using stpConsole.vPSM;
using UnityEngine;

namespace Console
{
    public class ConsoleVirtualTeleopState : ConsoleBaseState
    {
        public override void EnterState(ConsoleStateManager console)
        {
           Debug.Log("Console in Virutal Teleop State"); 
           console.transform.Find("vPSM").GetComponent<vPSMStateManager>().SwitchState(
               console.transform.Find("vPSM").GetComponent<vPSMStateManager>().vPSMState["EnabledState"]);
        }

        public override void UpdateState(ConsoleStateManager console)
        {
            
        }
        
        public override void ExitState(ConsoleStateManager console)
        {
           console.transform.Find("vPSM").GetComponent<vPSMStateManager>().SwitchState(
               console.transform.Find("vPSM").GetComponent<vPSMStateManager>().vPSMState["DisabledState"]);
        }
    }
}