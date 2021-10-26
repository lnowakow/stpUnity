using PointerTool;
using UnityEngine;

namespace Console
{
    public class ConsolePointerBallState : ConsoleBaseState
    {
        public override void EnterState(ConsoleStateManager console)
        {
           Debug.Log("Console In Pointer Ball State"); 
           console.transform.Find("PointerTool").transform.GetComponent<PointerStateManager>().SwitchState(
               console.transform.Find("PointerTool").transform.GetComponent<PointerStateManager>().PointerState["BallState"]);
        }

        public override void UpdateState(ConsoleStateManager console)
        {
            
        }
        
        public override void ExitState(ConsoleStateManager console)
        {
           console.transform.Find("PointerTool").transform.GetComponent<PointerStateManager>().SwitchState(
               console.transform.Find("PointerTool").transform.GetComponent<PointerStateManager>().PointerState["DisabledState"]);
        }
    }
}