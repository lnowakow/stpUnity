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
        public KeyValueReader _data;
        private string _previousKey, _previousValue;

        protected override void Start()
        {
            base.Start();
            InitializeMessage();
        }

        protected void Update()
        {
            if (_data._key != _previousKey || _data._value != _previousValue)
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
            _message.key = _data._key;
            _message.value = _data._value;
            Publish(_message);
            _previousKey = _data._key;
            _previousValue = _data._value;
        }
    }
}