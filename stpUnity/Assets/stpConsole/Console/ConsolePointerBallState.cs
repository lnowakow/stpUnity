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
           console.rosTopicData.mTeleopSelectTeleop._key = "MTMR_PRIMARY";
           console.rosTopicData.mTeleopSelectTeleop._value = "R1_CURSOR";
           console.stpConsoleROS.teleopSelectTeleop._data = console.rosTopicData.mTeleopSelectTeleop;
           console.stpConsoleROS.teleopSelectTeleop.ForceUpdate();
           // Update CURSOR operating state
           console.rosTopicData.mCURSOROperatingState.state = "ENABLED";
           console.rosTopicData.mCURSOROperatingState.is_home = true;
           console.stpConsoleROS.cursorOperatingState.data = console.rosTopicData.mCURSOROperatingState;
           console.stpConsoleROS.cursorOperatingState.ForceUpdate();
           // Update MTM operating state
           console.rosTopicData.mMTMOperatingState.state = "ENABLE";
           console.rosTopicData.mMTMOperatingState.is_home = true;
           console.dVRKConsoleROS.mtmOperatingState.data = console.rosTopicData.mMTMOperatingState;
           console.dVRKConsoleROS.mtmOperatingState.ForceUpdate();




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
           console.rosTopicData.mTeleopSelectTeleop._key = "MTMR_SECONDARY";
           console.rosTopicData.mTeleopSelectTeleop._value = "";
           console.stpConsoleROS.teleopSelectTeleop._data = console.rosTopicData.mTeleopSelectTeleop;
           console.stpConsoleROS.teleopSelectTeleop.ForceUpdate();
           // Update CURSOR operating state
           console.rosTopicData.mCURSOROperatingState.state = "DISABLED";
           console.rosTopicData.mCURSOROperatingState.is_home = true;
           console.stpConsoleROS.cursorOperatingState.data = console.rosTopicData.mCURSOROperatingState;
           console.stpConsoleROS.cursorOperatingState.ForceUpdate();
           // Update MTM operating state
           console.rosTopicData.mMTMOperatingState.state = "DISABLED";
           console.rosTopicData.mMTMOperatingState.is_home = true;
           console.dVRKConsoleROS.mtmOperatingState.data = console.rosTopicData.mMTMOperatingState;
           console.dVRKConsoleROS.mtmOperatingState.ForceUpdate();
        }
    }
}