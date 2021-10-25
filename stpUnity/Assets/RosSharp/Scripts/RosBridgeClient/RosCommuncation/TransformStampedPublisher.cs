
using UnityEngine;

namespace RosSharp.RosBridgeClient
{
    public class TransformStampedPublisher : UnityPublisher<MessageTypes.Geometry.TransformStamped>
    {
        public Transform PublishedTransform;
        public string FrameId = "Unity";

        private MessageTypes.Geometry.TransformStamped message;

        protected override void Start()
        {
            base.Start();
            InitializeMessage();
        }

        private void FixedUpdate()
        {
            UpdateMessage();
        }

        private void InitializeMessage()
        {
            message = new MessageTypes.Geometry.TransformStamped
            {
                header = new MessageTypes.Std.Header()
                {
                    frame_id = FrameId
                }
            };
        }

        private void UpdateMessage()
        {
            message.header.Update();
            GetGeometryPosition(PublishedTransform.position.Unity2Ros(), message.transform.translation);
            GetGeometryQuaternion(PublishedTransform.rotation.Unity2Ros(), message.transform.rotation);

            Publish(message);
        }

        private static void GetGeometryPosition(Vector3 position, MessageTypes.Geometry.Vector3 geometryPosition)
        {
            geometryPosition.x = position.x;
            geometryPosition.y = position.y;
            geometryPosition.z = position.z;
        }

        private static void GetGeometryQuaternion(Quaternion quaternion, MessageTypes.Geometry.Quaternion geometryQuaternion)
        {
            geometryQuaternion.x = quaternion.x;
            geometryQuaternion.y = quaternion.y;
            geometryQuaternion.z = quaternion.z;
            geometryQuaternion.w = quaternion.w;
        }

    }
}
