using UnityEngine;

namespace PointerTool
{
    public class PointerBallState : PointerBaseState
    {
        private Vector3 _initial_position = new Vector3(0, 0, 0);
        public override void EnterState(PointerStateManager pointer)
        {
            pointer.transform.GetChild(0).transform.position = _initial_position;
            pointer.transform.GetChild(0).gameObject.SetActive(true);
        }

        public override void UpdateState(PointerStateManager pointer)
        {
        }

        public override void ExitState(PointerStateManager pointer)
        {
            pointer.transform.GetChild(0).gameObject.SetActive(false);
        }
    }
}