using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Console;
using Footpedals;
using Menu;
using RosSharp.RosBridgeClient;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class ConsoleStateManager : MonoBehaviour
{
    public ConsoleBaseState currentState;
    public UnityEvent menuIsVisible, menuIsNotVisible;
    
    // ROS Topics for knowing console's state
    public class dVRK_Console_ROS
    {
        // Publishers
        public BoolPublisher teleopEnable;
        public KeyValuePublisher teleopSelectTeleop;
        // Subscribers

    } public dVRK_Console_ROS dVRKConsoleROS;

    public class stp_Console_ROS
    {
        // Publishers
        public OperatingStatePublisher cursorOperatingState;
        public KeyValuePublisher teleopSelectTeleop;
        // Subscribers
        
    } public stp_Console_ROS stpConsoleROS;
    
    public FootpedalStateManager _footpedals;
    
    [System.Serializable]
    public class ros_TOPIC_DATA
    {
        public KeyValueReader mTeleop;
        public OperatingStateReader mCURSOROperatingState;
    } public ros_TOPIC_DATA rosTopicData;

    public class ConsoleStates
    {
        private readonly Dictionary<string, ConsoleBaseState> console_states =
            new Dictionary<string, ConsoleBaseState>();

        public ConsoleStates()
        {
            console_states["SpectatorState"]= new ConsoleSpectatorState();
            console_states["PointerBallState"]= new ConsolePointerBallState();
            console_states["PointerLaserState"]= new ConsolePointerLaserState();
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
    public ConsoleStates ConsoleState = new ConsoleStates();
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Starting Console State Machine");
        currentState = ConsoleState["SpectatorState"];
        currentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        if (_footpedals.GetComponent<FootpedalStateManager>().FootpedalStateString == "MenuState")
        {
            menuIsVisible.Invoke();
        }
        else {
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
