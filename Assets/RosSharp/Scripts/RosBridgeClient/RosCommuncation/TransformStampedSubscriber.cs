/*
CSTAR
Author: Lukasz Nowakowski
Date: September 17, 2021
Version: 1.0.0
*/


using UnityEngine;

namespace RosSharp.RosBridgeClient
{
    [RequireComponent(typeof(RosConnector))]
    public class TransformStampedSubscriber : UnitySubscriber<MessageTypes.Geometry.TransformStamped>
    {
        public Transform transform;

        private MessageTypes.Geometry.Transform messageData;
        private Vector3 newPosition;
        private Quaternion newQuaternion;
        private bool isMessageReceived;

        protected override void Start()
        {
            base.Start();
        }

        private void Update()
        {
            if (isMessageReceived)
            {
                ProcessMessage();
            } 
        }

        protected override void ReceiveMessage(MessageTypes.Geometry.TransformStamped message)
        {
            messageData = message.transform;
            isMessageReceived = true;
        }

        private void ProcessMessage()
        {
            
            newPosition.x = (float)messageData.translation.x;
            newPosition.y = (float)messageData.translation.y;
            newPosition.z = (float)messageData.translation.z;
            newQuaternion.x = (float)messageData.rotation.x;
            newQuaternion.y = (float)messageData.rotation.y;
            newQuaternion.z = (float)messageData.rotation.z;
            newQuaternion.w = (float)messageData.rotation.w;

            transform.position = newPosition;
            transform.rotation = newQuaternion;
            isMessageReceived = false;

        }

    }
}
