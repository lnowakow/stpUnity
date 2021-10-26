using System;
using System.Collections.Generic;
using System.Diagnostics;
using RosSharp.RosBridgeClient;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace Footpedals
{
    public class FootpedalStateManager : MonoBehaviour
    {
        private FootpedalBaseState _currentState;
        private JoyButtonWriter[] _footpedals;

        public class FootpedalStates
        {
            private readonly Dictionary<string, FootpedalBaseState> _footpedalStates =
                new Dictionary<string, FootpedalBaseState>();

            public FootpedalStates()
            {
                _footpedalStates["ClutchedState"] = new FootpedalWaitState();
                _footpedalStates["InactiveState"] = new FootpedalInactiveState();
                _footpedalStates["InvalidState"] = new FootpedalInvalidState();
                _footpedalStates["MenuState"] = new FootpedalMenuState();
                _footpedalStates["TeleopActiveState"] = new FootpedalTeleopActiveState();
                _footpedalStates["WaitState"] = new FootpedalWaitState();
            }

            public FootpedalBaseState this[string key]
            {
                get => _footpedalStates[key];
                set => _footpedalStates[key] = value;
            }
        }
        public FootpedalStates FootpedalState = new FootpedalStates();
        [NonSerialized]
        public string FootpedalStateString;

        private bool[] _activePedals;
        
        void Start()
        {
            _footpedals = GetComponents<JoyButtonWriter>();
            _activePedals = new[] {_footpedals[0].state, _footpedals[1].state, _footpedals[2].state};
            FootpedalStateString = "InactiveState";
            _currentState = FootpedalState[FootpedalStateString];
            _currentState.EnterState(this);
        }

        void Update()
        {
            // check if there's a change in what pedal is pressed
            if (_footpedals[0].state != _activePedals[0] ||
                _footpedals[1].state != _activePedals[1] ||
                _footpedals[2].state != _activePedals[2])
            {
                //Debug.Log("Pedals have changed ...");
                if (!_footpedals[0].state && !_footpedals[1].state && !_footpedals[2].state)
                {
                    // no pedals
                    UpdateActivePedals(false, false, false);
                    FootpedalStateString = "InactiveState";

                } else if (_footpedals[0].state && !_footpedals[1].state && !_footpedals[2].state)
                {
                    // operator present
                    UpdateActivePedals(true, false, false);
                    FootpedalStateString = "TeleopActiveState";
                    
                } else if (!_footpedals[0].state && _footpedals[1].state && !_footpedals[2].state)
                {
                    // menu
                    UpdateActivePedals(false, true, false);
                    FootpedalStateString = "MenuState";
                    
                    
                } else if (_footpedals[0].state && _footpedals[1].state && !_footpedals[2].state)
                {
                    // operator present and menu
                    UpdateActivePedals(true, true, false);
                    FootpedalStateString = "WaitState";
                    
                } else if (!_footpedals[0].state && !_footpedals[1].state && _footpedals[2].state)
                {
                    // clutch
                    UpdateActivePedals(false, false, true);
                    FootpedalStateString = "WaitState";
                    
                } else if (_footpedals[0].state && !_footpedals[1].state && _footpedals[2].state)
                {
                    // operator present and clutch
                    UpdateActivePedals(true, false, true);
                    FootpedalStateString = "ClutchedState";
                    
                } else if (!_footpedals[0].state && _footpedals[1].state && _footpedals[2].state)
                {
                    // menu and clutch
                    UpdateActivePedals(false, true, true);
                    FootpedalStateString = "MenuState";
                    
                } else if (_footpedals[0].state && _footpedals[1].state && _footpedals[2].state)
                {
                    // operator present, menu and clutch
                    UpdateActivePedals(true, true, true);
                    FootpedalStateString = "WaitState";
                    
                }
                SwitchState(FootpedalState[FootpedalStateString]);
            }
            _currentState.UpdateState(this);
        }

        public void SwitchState(FootpedalBaseState state)
        {
            if (_currentState != state)
            {
                _currentState.ExitState(this);
                _currentState = state;
                _currentState.EnterState(this);
            }
        }

        private void UpdateActivePedals(bool op, bool menu, bool clutch)
        {
            _activePedals[0] = op;
            _activePedals[1] = menu;
            _activePedals[2] = clutch;
        }
    }
}