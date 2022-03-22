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
            console.dVRKConsoleROS.teleopEnable.status = true;
            console.rosTopicData.mTeleop._key = "MTMR_SECONDARY";
            console.rosTopicData.mTeleop._value = "PSM2";
            console.dVRKConsoleROS.teleopSelectTeleop._data = console.rosTopicData.mTeleop;
            
        }

        public override void UpdateState(ConsoleStateManager console)
        {
            
        }
        
        public override void ExitState(ConsoleStateManager console)
        {
            Debug.Log("Exiting MTMR_S teleop.");
            console.dVRKConsoleROS.teleopEnable.status = false;
            console.rosTopicData.mTeleop._key = "MTMR_SECONDARY";
            console.rosTopicData.mTeleop._value = "";
            console.dVRKConsoleROS.teleopSelectTeleop._data = console.rosTopicData.mTeleop;
            console.dVRKConsoleROS.teleopSelectTeleop.ForceUpdate();
            
        }
    }
}