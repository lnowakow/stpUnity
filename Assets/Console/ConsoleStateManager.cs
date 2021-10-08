using System.Collections;
using System.Collections.Generic;
using Console;
using UnityEngine;

public class ConsoleStateManager : MonoBehaviour
{
    public ConsoleBaseState currentState;
    
    // ROS Topics for knowing console's state
    
    
    // All possible states for a console
    private ConsoleSpectatorState SpectatorState = new ConsoleSpectatorState();
    private ConsoleCursorBallState CursorBallState = new ConsoleCursorBallState();
    private ConsoleCursorLaserState CursorLaserState = new ConsoleCursorLaserState();
    private ConsoleVirtualTeleopState VirtualTeleopState = new ConsoleVirtualTeleopState();
    private ConsoleRealTeleopMasterState RealTeleopMasterState = new ConsoleRealTeleopMasterState();
    private ConsoleRealTeleopSlaveState RealTeleopSlaveState = new ConsoleRealTeleopSlaveState();

    // Start is called before the first frame update
    void Start()
    {
        currentState = SpectatorState;
        currentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
