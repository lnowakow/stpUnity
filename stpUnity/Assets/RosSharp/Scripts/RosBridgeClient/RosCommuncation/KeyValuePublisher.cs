/*
CSTAR
Author: Lukasz Nowakowski
Date: October 9, 2021
Version: 1.0.0
*/

using System;
using UnityEngine;

namespace RosSharp.RosBridgeClient
{
    public class KeyValuePublisher : UnityPublisher<MessageTypes.Diagnostic.KeyValue>
    {
        private MessageTypes.Diagnostic.KeyValue _message;
        [HideInInspector] public string key, value;
        private string _previousKey, _previousValue;

        protected override void Start()
        {
            base.Start();
            InitializeMessage();
        }

        protected void Update()
        {
            if (key != _previousKey || value != _previousValue)
            {
               UpdateMessage(); 
            }
        }

        private void InitializeMessage()
        {
            _message = new MessageTypes.Diagnostic.KeyValue();
        }

        private void UpdateMessage()
        {
            _message.key = key;
            _message.value = value;
            Publish(_message);
            _previousKey = key;
            _previousValue = value;
        }
    }
}