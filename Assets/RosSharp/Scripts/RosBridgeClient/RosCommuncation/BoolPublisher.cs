/*
CSTAR
Author: Lukasz Nowakowski
Date: October 9, 2021
Version: 1.0.0
*/

using RosSharp.RosBridgeClient;
using System.Collections;
using UnityEngine;

namespace RosSharp.RosBridgeClient
{
    public class BoolPublisher : UnityPublisher<MessageTypes.Std.Bool>
    {
        private MessageTypes.Std.Bool _message;
        [HideInInspector]
        public bool status;
        private bool _previousStatus;
        protected override void Start()
        {
            base.Start();
            InitializeMessage();
        }

        private void Update()
        {
            if (status != _previousStatus)
            {
                UpdateMessage();
            }
        }
        
        private void InitializeMessage()
        {
            _message = new MessageTypes.Std.Bool
            {
                data = status
            };
        }

        private void UpdateMessage()
        {
            _message.data = status;
            Publish(_message);
            _previousStatus = status;
        }
    }
}