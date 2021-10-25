using PointerTool;
using UnityEngine;

namespace Console
{
    public class ConsolePointerLaserState : ConsoleBaseState
    {
        public override void EnterState(ConsoleStateManager console)
        {
           Debug.Log("Console in Cursor Laser State"); 
           console.transform.GetChild(4).transform.GetComponent<PointerStateManager>().SwitchState(
               console.transform.GetChild(4).transform.GetComponent<PointerStateManager>().PointerState["LaserState"]);
        }

        public override void UpdateState(ConsoleStateManager console)
        {
            
        }
        
        public override void ExitState(ConsoleStateManager console)
        {
           console.transform.GetChild(4).transform.GetComponent<PointerStateManager>().SwitchState(
               console.transform.GetChild(4).transform.GetComponent<PointerStateManager>().PointerState["DisabledState"]);
            
        }
    }
}