using System;
using RosSharp.RosBridgeClient;
using UnityEngine;

namespace Console
{
    public class ConsoleRealTeleopMasterState : ConsoleBaseState
    {
        public override void EnterState(ConsoleStateManager console)
        {
            Debug.Log("Console " + console.name + ": in RealTeleopMaster State.");
            Debug.Log("Entering into MTMR_P teleop");
            console.dVRKConsoleROS.teleopEnable.status = true;
            console.rosTopicData.mTeleop._key = "MTMR_PRIMARY";
            console.rosTopicData.mTeleop._value = "PSM2";
            console.dVRKConsoleROS.teleopSelectTeleop._data = console.rosTopicData.mTeleop;
        }

        public override void UpdateState(ConsoleStateManager console)
        {
            
        }
        
        public override void ExitState(ConsoleStateManager console)
        {
            Debug.Log("Exiting from MTMR_P teleop");
            console.dVRKConsoleROS.teleopEnable.status = false;
            console.rosTopicData.mTeleop._key = "MTMR_PRIMARY";
            console.rosTopicData.mTeleop._value = "";
            console.dVRKConsoleROS.teleopSelectTeleop._data = console.rosTopicData.mTeleop;
            console.dVRKConsoleROS.teleopSelectTeleop.ForceUpdate();
        }
    }
}