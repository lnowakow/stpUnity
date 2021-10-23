/*
CSTAR
Author: Lukasz Nowakowski
Date: September 17, 2021
Version: 1.0.0
*/


using UnityEngine;

namespace RosSharp.RosBridgeClient
{
    public class StringStateSubscriber : UnitySubscriber<MessageTypes.Crtk.StringStamped>
    {
        public Transform transform;

        private MessageTypes.Crtk.StringStamped _messageData;
        // implement private StringStampedWriter stringStampedWriter;
        private bool _isMessageReceived;

        protected override void Start()
        {
            base.Start();
        }

        private void Update()
        {
            if (_isMessageReceived)
            {
                ProcessMessage();
            } 
        }

        protected override void ReceiveMessage(MessageTypes.Crtk.StringStamped message)
        {
        }

        private void ProcessMessage()
        {
            
        }

    }
}
