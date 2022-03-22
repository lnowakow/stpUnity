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
           console.dVRKConsoleROS.teleopEnable.status = true;
           // Doing this unselects any current selected teleop in dVRK and throws a warning it doesn't exist. OK.
           console.rosTopicData.mTeleop._key = "MTMR_PRIMARY";
           console.rosTopicData.mTeleop._value = "R1_CURSOR";
           console.stpConsoleROS.teleopSelectTeleop._data = console.rosTopicData.mTeleop;
           console.stpConsoleROS.teleopSelectTeleop.ForceUpdate();
           // Update CURSOR operating state
           console.rosTopicData.mCURSOROperatingState._state = "ENABLED";
           console.rosTopicData.mCURSOROperatingState._is_home = true;
           console.stpConsoleROS.cursorOperatingState.data = console.rosTopicData.mCURSOROperatingState;
           console.stpConsoleROS.cursorOperatingState.ForceUpdate();
           // Update MTM operating state
           



        }

        public override void UpdateState(ConsoleStateManager console)
        {
            
        }
        
        public override void ExitState(ConsoleStateManager console)
        {
           console.transform.Find("ECM/outer_yaw_joint/outer_yaw_revolute/outer_pitch_joint/PointerTool").transform.GetComponent<PointerStateManager>().SwitchState(
               console.transform.Find("ECM/outer_yaw_joint/outer_yaw_revolute/outer_pitch_joint/PointerTool").transform.GetComponent<PointerStateManager>().PointerState["DisabledState"]);
           // Unselect current selected teleop
           console.dVRKConsoleROS.teleopEnable.status = false;
           console.rosTopicData.mTeleop._key = "MTMR_SECONDARY";
           console.rosTopicData.mTeleop._value = "";
           console.stpConsoleROS.teleopSelectTeleop._data = console.rosTopicData.mTeleop;
           console.stpConsoleROS.teleopSelectTeleop.ForceUpdate();
        }
    }
}