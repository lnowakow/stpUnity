using System;
using UnityEngine;

namespace Console
{
    public class ConsoleRealTeleopSlaveState : ConsoleBaseState
    {
        public override void EnterState(ConsoleStateManager console)
        {
            Debug.Log("Console In Real Teleop Slave State");
            Debug.Log("Entering into MTMR_S teleop.");
            console._dvrk_console_teleop_enable.status = true;
            console.dvrk_names.mTeleop._key = "MTMR_SECONDARY";
            console.dvrk_names.mTeleop._value = "PSM2";
            console._dvrk_console_teleop_select_teleop._data = console.dvrk_names.mTeleop;
            
        }

        public override void UpdateState(ConsoleStateManager console)
        {
            
        }
        
        public override void ExitState(ConsoleStateManager console)
        {
            Debug.Log("Exiting MTMR_S teleop.");
            console._dvrk_console_teleop_enable.status = false;
            console.dvrk_names.mTeleop._key = "MTMR_SECONDARY";
            console.dvrk_names.mTeleop._value = "";
            console._dvrk_console_teleop_select_teleop._data = console.dvrk_names.mTeleop;
            console._dvrk_console_teleop_select_teleop.ForceUpdate();
            
        }
    }
}