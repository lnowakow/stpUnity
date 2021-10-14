using UnityEngine;

namespace Console
{
    public class ConsoleCursorLaserState : ConsoleBaseState
    {
        public override void EnterState(ConsoleStateManager console)
        {
           Debug.Log("Console in Cursor Laser State"); 
        }

        public override void UpdateState(ConsoleStateManager console)
        {
            
        }
        
        public override void ExitState(ConsoleStateManager console)
        {
            
        }
    }
}