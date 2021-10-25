using UnityEngine;

namespace PointerTool
{
    public class PointerLaserState : PointerBaseState
    {
        private Vector3 _initial_position = new Vector3(0, 0, 0);
        public override void EnterState(PointerStateManager pointer)
        {
            pointer.transform.GetChild(1).transform.position = _initial_position;
            pointer.transform.GetChild(1).gameObject.SetActive(true);
        }

        public override void UpdateState(PointerStateManager pointer)
        {
        }

        public override void ExitState(PointerStateManager pointer)
        {
            pointer.transform.GetChild(1).gameObject.SetActive(false);
        }
    }
}