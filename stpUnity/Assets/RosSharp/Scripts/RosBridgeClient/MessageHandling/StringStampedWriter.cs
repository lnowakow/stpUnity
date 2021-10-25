/*
CSTAR
Author: Lukasz Nowakowski
Date: September 17, 2021
Version: 1.0.0
*/

using UnityEngine;

namespace RosSharp.RosBridgeClient
{
    public class StringStampedWriter : MonoBehaviour
    {
        private MessageTypes.Crtk.StringStamped StringStamped;
        
        public void Write(MessageTypes.Crtk.StringStamped msg)
        {
            StringStamped = msg;
        }
    }
}
