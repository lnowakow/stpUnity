using RosSharp.RosBridgeClient;
using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UIElements;

namespace RosSharp.RosBridgeClient
{
    public class OperatingStatePublisher : UnityPublisher<MessageTypes.Crtk.OperatingState>
    {
        private MessageTypes.Crtk.OperatingState _operating_state;
        [HideInInspector] public OperatingStateReader data;
        private string _previousState;
        
        protected override void Start()
        {
            base.Start();
            InitializeMessage();
        }

        private void Update()
        {
            if (data._state != _previousState)
            {
                UpdateMessage();
            }
        }
        
        private void InitializeMessage()
        {
            _operating_state = new MessageTypes.Crtk.OperatingState()
            {
                state = data._state,
                is_homed = data._is_home,
                is_busy = data._is_busy
            };
        }

        private void UpdateMessage()
        {
            _operating_state.state = data._state;
            _operating_state.is_homed = data._is_home;
            _operating_state.is_busy = data._is_busy;
            Publish(_operating_state);
            _previousState = data._state;
        }

        public void ForceUpdate()
        {
            UpdateMessage();
        }
        
    }
}
