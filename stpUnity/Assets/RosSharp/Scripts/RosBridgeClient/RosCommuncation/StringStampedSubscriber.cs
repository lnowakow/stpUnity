/*
CSTAR
Author: Lukasz Nowakowski
Date: September 17, 2021
Version: 1.0.0
*/


using UnityEngine;

namespace RosSharp.RosBridgeClient
{
    public class StringStampedSubscriber : UnitySubscriber<MessageTypes.Crtk.StringStamped>
    {
        // Could implement private StringStampedWriter stringStampedWriter;
        public StringStampedWriter state;

        protected override void Start()
        {
            base.Start();
        }

        protected override void ReceiveMessage(MessageTypes.Crtk.StringStamped message)
        {
            state.Write(message);
        }

    }
}
