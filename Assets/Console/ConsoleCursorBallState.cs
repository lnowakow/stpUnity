using UnityEngine;

namespace Console
{
    public class ConsoleCursorBallState : ConsoleBaseState
    {
        public override void EnterState(ConsoleStateManager console)
        {
           Debug.Log("Console In Cursor Ball State"); 
        }

        public override void UpdateState(ConsoleStateManager console)
        {
            
        }
        
        public override void ExitState(ConsoleStateManager console)
        {
            
        }
    }
}