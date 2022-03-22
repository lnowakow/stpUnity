using System;
using System.Collections.Generic;
using RosSharp.RosBridgeClient;
using RosSharp.RosBridgeClient.MessageTypes.Crtk;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace PointerTool
{
    public class PointerStateManager : MonoBehaviour
    {
        public PointerBaseState currentState;
        public string currentStateString;

        public OperatingStatePublisher cursorOperatingState;

        public class cursor_topic_data
        {
            public OperatingStateReader mOperatingState;
        } public cursor_topic_data cursorTopicData;
        
        public class PointerStates
        {
            private readonly Dictionary<string, PointerBaseState> pointer_states =
                new Dictionary<string, PointerBaseState>();

            public PointerStates()
            {
                pointer_states["BallState"] = new PointerBallState();
                pointer_states["LaserState"] = new PointerLaserState();
                pointer_states["DisabledState"] = new PointerDisabledState();
            }

            public PointerBaseState this[string key]
            {
                get => pointer_states[key];
                set => pointer_states[key] = value;
            }
        } public PointerStates PointerState = new PointerStates();

        private void Start()
        {
            Debug.Log("Starting Pointer Tool");
            currentStateString = "DisabledState";
            currentState = PointerState[currentStateString];
        }

        public void Update()
        {
            currentState.UpdateState(this);
        }

        public void SwitchState(PointerBaseState state)
        {
            if (state != currentState)
            {
                currentState = state;
                currentState.EnterState(this);
            }
        }
        
    }
}