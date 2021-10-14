using System;
using UnityEngine;

namespace Console
{
    public class ConsoleSpectatorState : ConsoleBaseState
    {
        public override void EnterState(ConsoleStateManager console)
        {
            Debug.Log("Console " + console.name + ": in Spectator State.");
        }

        public override void UpdateState(ConsoleStateManager console)
        {
            
        }

        public override void ExitState(ConsoleStateManager console)
        {
            
        }
    }
}