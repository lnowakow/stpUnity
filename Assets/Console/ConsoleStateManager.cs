using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Console;
using RosSharp.RosBridgeClient;
using UnityEngine;

public class ConsoleStateManager : MonoBehaviour
{
    public ConsoleBaseState currentState;
    
    // ROS Topics for knowing console's state
    // Publishers
    public BoolPublisher _console_teleop_enable;
    public KeyValuePublisher _console_teleop_select_teleop;
    // Subscribers

    [System.Serializable]
    public class dVRK_INFO
    {
        public string mMTM;
        public string mPSM;
        public string mCURSOR;
    }

    public dVRK_INFO dvrk_names;
    
    // All possible states for a console
    public ConsoleSpectatorState SpectatorState = new ConsoleSpectatorState();
    public ConsoleCursorBallState CursorBallState = new ConsoleCursorBallState();
    public ConsoleCursorLaserState CursorLaserState = new ConsoleCursorLaserState();
    public ConsoleVirtualTeleopState VirtualTeleopState = new ConsoleVirtualTeleopState();
    public ConsoleRealTeleopMasterState RealTeleopMasterState = new ConsoleRealTeleopMasterState();
    public ConsoleRealTeleopSlaveState RealTeleopSlaveState = new ConsoleRealTeleopSlaveState();

    // Start is called before the first frame update
    void Start()
    {
        currentState = SpectatorState;
        currentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this);
    }

    public void SwitchState(ConsoleBaseState state)
    {
        currentState.ExitState(this);
        currentState = state;
        currentState.EnterState(this);
    }
}
