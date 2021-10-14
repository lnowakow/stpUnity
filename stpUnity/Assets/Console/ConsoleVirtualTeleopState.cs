using UnityEngine;

namespace Console
{
    public class ConsoleVirtualTeleopState : ConsoleBaseState
    {
        public override void EnterState(ConsoleStateManager console)
        {
           Debug.Log("Console in Virutal Teleop State"); 
        }

        public override void UpdateState(ConsoleStateManager console)
        {
            
        }
        
        public override void ExitState(ConsoleStateManager console)
        {
            
        }
    }
}