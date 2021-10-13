using UnityEngine;

namespace Console
{
    public class ConsoleRealTeleopSlaveState : ConsoleBaseState
    {
        public override void EnterState(ConsoleStateManager console)
        {
            Debug.Log("Console In Real Teleop Slave State");
            
        }

        public override void UpdateState(ConsoleStateManager console)
        {
            
        }
        
        public override void ExitState(ConsoleStateManager console)
        {
            
        }
    }
}