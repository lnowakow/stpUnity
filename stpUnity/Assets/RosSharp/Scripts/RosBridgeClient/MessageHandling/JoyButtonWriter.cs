/*
CSTAR
Author: Lukasz Nowakowski
Date: September 17, 2021
Version: 1.0.0
*/


using UnityEngine;

namespace RosSharp.RosBridgeClient
{
    public class JoyButtonWriter : MonoBehaviour
    {
        public bool state;
        private bool previousState;
        public void Write(int value)
        {
            
            if (value == 1)
            {
                //Debug.Log("State is now true");
                state = true;
            }
            else
            {
                //Debug.Log("State is now false");
                state = false;
            }
        }
    }
}
