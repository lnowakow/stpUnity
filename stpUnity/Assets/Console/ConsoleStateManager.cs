using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Console;
using Menu;
using RosSharp.RosBridgeClient;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class ConsoleStateManager : MonoBehaviour
{
    public ConsoleBaseState currentState;
    public UnityEvent menuIsVisible, menuIsNotVisible;
    public MenuStateManager menu;
    
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

    public class ConsoleStates
    {
        private readonly Dictionary<string, ConsoleBaseState> console_states =
            new Dictionary<string, ConsoleBaseState>();

        public ConsoleStates()
        {
            console_states["SpectatorState"]= new ConsoleSpectatorState();
            console_states["CursorBallState"]= new ConsoleCursorBallState();
            console_states["CursorLaserState"]= new ConsoleCursorLaserState();
            console_states["RealTeleopMasterState"]= new ConsoleRealTeleopMasterState();
            console_states["RealTeleopSlaveState"]= new ConsoleRealTeleopSlaveState();
            console_states["VirtualTeleopState"]= new ConsoleVirtualTeleopState();
        }

        public ConsoleBaseState this[string key]
        {
            get => console_states[key];
            set => console_states[key] = value;
        }
    }
    public ConsoleStates console_states = new ConsoleStates();
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Starting Console State Machine");
        currentState = console_states["SpectatorState"];
        currentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        JoyButtonWriter[] footpedals = gameObject.GetComponents<JoyButtonWriter>();

        if (!footpedals[0].state && !footpedals[1].state)
        {
            menuIsVisible.Invoke();
        }
        else if (!footpedals[1].state)
        {
            menuIsNotVisible.Invoke();
        }
        
        currentState.UpdateState(this);
    }

    public void SwitchState(ConsoleBaseState state)
    {
        if (state != currentState)
        {
            currentState.ExitState(this);
            currentState = state;
            currentState.EnterState(this);
        }
    }
}
