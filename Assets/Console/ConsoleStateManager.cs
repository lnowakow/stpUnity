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
        private readonly Dictionary<MenuBaseState, ConsoleBaseState> console_states =
            new Dictionary<MenuBaseState, ConsoleBaseState>();

        public ConsoleStates()
        {
            console_states[new MenuSpectatorState()] = new ConsoleSpectatorState();
            console_states[new MenuCursorBallState()] = new ConsoleCursorBallState();
            console_states[new MenuCursorLaserState()] = new ConsoleCursorLaserState();
            console_states[new MenuRealTeleopMasterState()] = new ConsoleRealTeleopMasterState();
            console_states[new MenuRealTeleopSlaveState()] = new ConsoleRealTeleopSlaveState();
            console_states[new MenuVirtualTeleopState()] = new ConsoleVirtualTeleopState();
        }

        public ConsoleBaseState this[MenuBaseState key]
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
        Debug.Log("The initial state is " + console_states[new MenuCursorBallState()].ToString());
        currentState = console_states[new MenuCursorBallState()];
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
        currentState.ExitState(this);
        currentState = state;
        currentState.EnterState(this);
    }
}
