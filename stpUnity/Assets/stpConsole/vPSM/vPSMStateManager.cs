using System;
using System.Collections.Generic;
using UnityEngine;

namespace stpConsole.vPSM
{
    public class vPSMStateManager : MonoBehaviour
    {
        public vPSMBaseState currentState;
        public string currentStateString;
        
        public class vPSMStates
        {
            private readonly Dictionary<string, vPSMBaseState> vpsm_states = new Dictionary<string, vPSMBaseState>();

            public vPSMStates()
            {
                vpsm_states["EnabledState"] = new vPSMEnabledState();
                vpsm_states["DisabledState"] = new vPSMDisabledState();
            }

            public vPSMBaseState this[string key]
            {
                get => vpsm_states[key];
                set => vpsm_states[key] = value;
            }
        } public vPSMStates vPSMState = new vPSMStates();

        private void Start()
        {
            currentStateString = "DisabledState";
            Debug.Log("vPSMs started in " + currentStateString);
            currentState = vPSMState[currentStateString];
            currentState.EnterState(this);
        }

        private void Update()
        {
            currentState.UpdateState(this);
        }

        public void SwitchState(vPSMBaseState state)
        {
            if (state != currentState)
            {
                currentState.ExitState(this);
                currentState = state;
                currentState.EnterState(this);
            }
        }
    }
}