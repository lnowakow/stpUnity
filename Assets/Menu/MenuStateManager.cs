using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Menu;
using RosSharp.RosBridgeClient;
using UnityEngine;



public class MenuStateManager : MonoBehaviour
{
    public MenuBaseState currentState;
    public string optionSelected = "none";

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
                {"main_options", new int[] {0, 1, 2, 3, 10}},
                {"CursorButton", new int[] {4, 5}},
                {"rPSMButton", new int[] {6}},
                {"vPSMButton", new[] {7}},
                {"FollowButton", new int[] {8, 9}},
                {"none", new int[] {4, 5, 6, 7, 8, 9}}
            };
        }    
        public int[] this[string key]
        {
            get { return menu_options[key]; }
            set { menu_options[key] = value;  }
        }
    }
    

    public MenuOptions menu_options = new MenuOptions();

    //[System.Serializable]
    public class dVRK_INFO
    {
        public string mMTM;
        public string mPSM;
        public string mCURSOR;
        public string mFOOTPEDAL_CLUTCH;
        public string mFOOTPEDAL_CAMERA;
        public string mFOOTPEDAL_COAG;
    }

    public dVRK_INFO dvrk_names;
    
    // All possible states for a console
    public MenuSpectatorState SpectatorState = new MenuSpectatorState();
    public MenuCursorBallState CursorBallState = new MenuCursorBallState();
    public MenuCursorLaserState CursorLaserState = new MenuCursorLaserState();
    public MenuVirtualTeleopState VirtualTeleopState = new MenuVirtualTeleopState();
    public MenuRealTeleopMasterState RealTeleopMasterState = new MenuRealTeleopMasterState();
    public MenuRealTeleopSlaveState RealTeleopSlaveState = new MenuRealTeleopSlaveState();

    // Start is called before the first frame update
    void Start()
    {
        optionSelected = "none";
        currentState = CursorBallState;
        currentState.EnterState(this, optionSelected);
    }

    // Update is called once per frame
    void Update()
    {
        JoyButtonWriter[] footpedals = gameObject.GetComponents<JoyButtonWriter>();

        if (!footpedals[0].state && footpedals[1].state)
        {
            currentState.UpdateState(this, optionSelected);
        }
        else
        {
            //Debug.Log("The Menu should not be visible");
            for (int i = 0; i < gameObject.transform.childCount; i++)
            {
                gameObject.transform.GetChild(i).gameObject.SetActive(false);
            }
            
        }
    }

    public void SwitchState(MenuBaseState state)
    {
        currentState = state;
        currentState.EnterState(this, optionSelected);
    }
}
