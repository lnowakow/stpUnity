using UnityEngine;

namespace RosSharp.RosBridgeClient
{
    public class OperatingStateReader : MonoBehaviour
    {
        public string _state;
        public bool _is_home;
        public bool _is_busy;

        public void Read(string state, bool is_home, bool is_busy)
        {
            _state = state;
            _is_home = is_home;
            _is_busy = is_busy;
        }
        
    }
}
