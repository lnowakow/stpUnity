using System;
using RosSharp.RosBridgeClient;
using System.Collections;
using RosSharp.RosBridgeClient.MessageTypes.Crtk;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UIElements;

namespace RosSharp.RosBridgeClient
{
    public class OperatingStatePublisher : UnityPublisher<OperatingState>
    {
        public OperatingState data = new OperatingState(null, "", true, false);
        private string _previousState = "";
        
        protected override void Start()
        {
            base.Start();
        }

        private void Update()
        {
            //Debug.Log(_previousState);
            /*if (data.state != _previousState)
            {
                UpdateMessage();
            }
            */
        }
        
        private void UpdateMessage()
        {
            Publish(data);
            _previousState = data.state;
        }

        public void ForceUpdate()
        {
            UpdateMessage();
        }
        
    }
}
