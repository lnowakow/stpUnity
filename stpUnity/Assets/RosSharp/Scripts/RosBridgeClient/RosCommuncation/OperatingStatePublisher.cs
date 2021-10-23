using RosSharp.RosBridgeClient;
using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UIElements;

namespace RosSharp.RosBridgeClient
{
    public class OperatingStatePublisher : UnityPublisher<MessageTypes.Crtk.Operating_state>
    {
        private MessageTypes.Crtk.Operating_state _operating_state;
        [HideInInspector]
        public string _status;

        public bool _is_homed;
        public bool _is_busy;
        private string _previousStatus;
        
        protected override void Start()
        {
            base.Start();
            InitializeMessage();
        }

        private void Update()
        {
            if (_status != _previousStatus)
            {
                UpdateMessage();
            }
        }
        
        private void InitializeMessage()
        {
            _operating_state = new MessageTypes.Crtk.Operating_state()
            {
                state = _status,
                is_homed = _is_homed,
                is_busy = _is_busy
            };
        }

        private void UpdateMessage()
        {
            _operating_state.state = _status;
            _operating_state.is_homed = _is_homed;
            _operating_state.is_busy = _is_busy;
            Publish(_operating_state);
            _previousStatus = _status;
        }
    }
}
