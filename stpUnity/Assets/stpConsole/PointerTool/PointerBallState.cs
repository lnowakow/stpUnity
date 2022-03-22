using UnityEngine;

namespace PointerTool
{
    public class PointerBallState : PointerBaseState
    {
        private Vector3 _initial_position = new Vector3(0, 0, 0);
        public override void EnterState(PointerStateManager pointer)
        {
            pointer.transform.Find("Sphere").transform.localPosition = _initial_position;
            pointer.transform.Find("Sphere").gameObject.SetActive(true);
            // Update the state of this object as it's selected.
            pointer.cursorTopicData.mOperatingState._is_home = true;
            pointer.cursorTopicData.mOperatingState._state = "ENABLED";
        }

        public override void UpdateState(PointerStateManager pointer)
        {
        }

        public override void ExitState(PointerStateManager pointer)
        {
            pointer.transform.Find("Sphere").gameObject.SetActive(false);
            pointer.cursorTopicData.mOperatingState._state = "DISABLED";
        }
    }
}