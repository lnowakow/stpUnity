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
            console._console_teleop_enable.status = true;
            console.dvrk_names.mTeleop._key = "MTMR_PRIMARY";
            console.dvrk_names.mTeleop._value = "PSM2";
            console._console_teleop_select_teleop._data = console.dvrk_names.mTeleop;
        }

        public override void UpdateState(ConsoleStateManager console)
        {
            
        }
        
        public override void ExitState(ConsoleStateManager console)
        {
            Debug.Log("Exiting from MTMR_P teleop");
            console._console_teleop_enable.status = false;
            console.dvrk_names.mTeleop._key = "MTMR_PRIMARY";
            console.dvrk_names.mTeleop._value = "";
            console._console_teleop_select_teleop._data = console.dvrk_names.mTeleop;
            console._console_teleop_select_teleop.ForceUpdate();
        }
    }
}