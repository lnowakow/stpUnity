using PointerTool;
using UnityEngine;

namespace Console
{
    public class ConsolePointerBallState : ConsoleBaseState
    {
        public override void EnterState(ConsoleStateManager console)
        {
           Debug.Log("Console In Pointer Ball State"); 
           console.transform.Find("ECM/outer_yaw_joint/outer_yaw_revolute/outer_pitch_joint/PointerTool").transform.GetComponent<PointerStateManager>().SwitchState(
               console.transform.Find("ECM/outer_yaw_joint/outer_yaw_revolute/outer_pitch_joint/PointerTool").transform.GetComponent<PointerStateManager>().PointerState["BallState"]);
           console._dvrk_console_teleop_enable.status = true;
           console.dvrk_names.mTeleop._key = "MTMR_SECONDARY";
           console.dvrk_names.mTeleop._value = "R2_CURSOR";
           console._dvrk_console_teleop_select_teleop._data = console.dvrk_names.mTeleop;
           
        }

        public override void UpdateState(ConsoleStateManager console)
        {
            
        }
        
        public override void ExitState(ConsoleStateManager console)
        {
           console.transform.Find("ECM/outer_yaw_joint/outer_yaw_revolute/outer_pitch_joint/PointerTool").transform.GetComponent<PointerStateManager>().SwitchState(
               console.transform.Find("ECM/outer_yaw_joint/outer_yaw_revolute/outer_pitch_joint/PointerTool").transform.GetComponent<PointerStateManager>().PointerState["DisabledState"]);
           console._dvrk_console_teleop_enable.status = false;
           console.dvrk_names.mTeleop._key = "MTMR_SECONDARY";
           console.dvrk_names.mTeleop._value = "";
           console._dvrk_console_teleop_select_teleop._data = console.dvrk_names.mTeleop;
           console._dvrk_console_teleop_select_teleop.ForceUpdate();
        }
    }
}