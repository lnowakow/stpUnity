using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Menu;
using RosSharp.RosBridgeClient;
using UnityEngine;



public class MenuStateManager : MonoBehaviour
{
    public MenuBaseState currentState;
    // Drop the "Menu" word from state class
    public string currentStateString;

    public Cursor cursor;

    // ROS Topics for knowing console's state
    // Publishers
    
    // Subscribers

    public class MenuOptions
    {
        private readonly Dictionary<string, int[]> menu_options;

        public MenuOptions()
        {
            menu_options = new Dictionary<string, int[]>
            {
                {"main_options", new [] {0, 1, 2, 3, 10}},
                {"sub_options", new [] {4, 5, 6, 7, 8, 9}}
            };
        }    
        public int[] this[string key]
        {
            get { return menu_options[key]; }
            set { menu_options[key] = value;  }
        }
    }

    public MenuOptions menu_options = new MenuOptions();

    public class MenuStates
    {
        private readonly Dictionary<string, MenuBaseState> menu_states = new Dictionary<string, MenuBaseState>();

        public MenuStates()
        {
            menu_states["SpectatorButton"] = new MenuSpectatorState();
            menu_states["CursorBallButton"] = new MenuCursorBallState();
            menu_states["CursorLaserButton"] = new MenuCursorLaserState();
            menu_states["RequestrPSMButton"] = new MenuRealTeleopMasterState();
            menu_states["RequestvPSMButton"] = new MenuVirtualTeleopState();
            menu_states["RequestMasterButton"] = new MenuRealTeleopMasterState();
            menu_states["RequestSlaveButton"] = new MenuRealTeleopSlaveState();
        }

        public MenuBaseState this[string key]
        {
            get => menu_states[key];
            set => menu_states[key] = value;
        }
    }

    public MenuStates MenuState = new MenuStates();
    
    // All possible states for a console
    /*
    public MenuSpectatorState SpectatorState = new MenuSpectatorState();
    public MenuCursorBallState CursorBallState = new MenuCursorBallState();
    public MenuCursorLaserState CursorLaserState = new MenuCursorLaserState();
    public MenuVirtualTeleopState VirtualTeleopState = new MenuVirtualTeleopState();
    public MenuRealTeleopMasterState RealTeleopMasterState = new MenuRealTeleopMasterState();
    public MenuRealTeleopSlaveState RealTeleopSlaveState = new MenuRealTeleopSlaveState();
    */
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Starting Menu State Machine");
        currentState = MenuState["SpectatorButton"];
        currentStateString = "SpectatorState";
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this, cursor);
    }

    public void SwitchState(MenuBaseState state)
    {
        if (state != currentState)
        {
            currentState = state;
            currentState.EnterState(this, cursor);
        }
    }

    private void expandMenu(string option)
    {
            //Debug.Log(menu_options[option].Length);
            for (int i = 0; i < menu_options[option].Length; i++)
            {
                //Debug.Log("i:" + i + " is " + gameObject.transform.GetChild(i).name);
                gameObject.transform.GetChild(menu_options[option][i]).gameObject.SetActive(true);
            }
    }
}
