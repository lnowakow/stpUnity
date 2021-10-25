namespace PointerTool
{
    public class PointerDisabledState : PointerBaseState
    {
        public override void EnterState(PointerStateManager pointer)
        {
            pointer.transform.GetChild(0).gameObject.SetActive(false);
            pointer.transform.GetChild(1).gameObject.SetActive(false);
        }

        public override void UpdateState(PointerStateManager pointer)
        {
        }

        public override void ExitState(PointerStateManager pointer)
        {
        }
    }
}