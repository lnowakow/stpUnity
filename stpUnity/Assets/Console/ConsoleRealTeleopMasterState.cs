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
            
            console._console_teleop_enable.status = true;
            console._console_teleop_select_teleop.key = console.dvrk_names.mMTM;
            console._console_teleop_select_teleop.value = console.dvrk_names.mPSM;
        }

        public override void UpdateState(ConsoleStateManager console)
        {
            
        }
        
        public override void ExitState(ConsoleStateManager console)
        {
            console._console_teleop_enable.status = false;
            console._console_teleop_select_teleop.key = console.dvrk_names.mMTM;
            console._console_teleop_select_teleop.value = String.Empty;
        }
    }
}