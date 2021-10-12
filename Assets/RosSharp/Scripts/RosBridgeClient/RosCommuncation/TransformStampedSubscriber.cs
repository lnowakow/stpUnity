/*
CSTAR
Author: Lukasz Nowakowski
Date: September 17, 2021
Version: 1.0.0
*/


using UnityEngine;

namespace RosSharp.RosBridgeClient
{
    public class TransformStampedSubscriber : UnitySubscriber<MessageTypes.Geometry.TransformStamped>
    {
        public Transform transform;

        private MessageTypes.Geometry.Transform _messageData;
        private Vector3 _newPosition;
        private Quaternion _newQuaternion;
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

        protected override void ReceiveMessage(MessageTypes.Geometry.TransformStamped message)
        {
            _messageData = message.transform;
            _isMessageReceived = true;
        }

        private void ProcessMessage()
        {
            
            _newPosition.x = (float)_messageData.translation.x;
            _newPosition.y = (float)_messageData.translation.y;
            _newPosition.z = (float)_messageData.translation.z;
            _newQuaternion.x = (float)_messageData.rotation.x;
            _newQuaternion.y = (float)_messageData.rotation.y;
            _newQuaternion.z = (float)_messageData.rotation.z;
            _newQuaternion.w = (float)_messageData.rotation.w;

            transform.position = _newPosition;
            transform.rotation = _newQuaternion;
            _isMessageReceived = false;

        }

    }
}
