/*
 * CSTAR
 * Author: Lukasz Nowakowski
 * Date: October 25, 2021
 * Version: 1.0.0
 */


using RosSharp.RosBridgeClient.MessageTypes.Std;

namespace RosSharp.RosBridgeClient.MessageTypes.Crtk
{
    public class Operating_state : Message
    {
        public const string RosMessageName = "crtk_msgs/Operating_state";

        // 
        //  See https://github.com/collaborative-robotics/documentation/wiki/Robot-API-status
        // 
        //  Standard states include DISABLED, ENABLED, PAUSED and FAULT
        // 
        public Header header { get; set; }
        public string state { get; set; }
        public bool is_homed { get; set; }
        public bool is_busy { get; set; }

        public Operating_state()
        {
            this.header = new Header();
            this.state = "";
            this.is_homed = false;
            this.is_busy = false;
        }

        public Operating_state(Header header, string state, bool is_homed, bool is_busy)
        {
            this.header = header;
            this.state = state;
            this.is_homed = is_homed;
            this.is_busy = is_busy;
        }
    }
}
