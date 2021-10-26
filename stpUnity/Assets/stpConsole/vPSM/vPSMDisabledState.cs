namespace stpConsole.vPSM
{
    public class vPSMDisabledState : vPSMBaseState
    {
        public override void EnterState(vPSMStateManager vPSM)
        {
            vPSM.currentStateString = "DisabledState";
            vPSM.transform.Find("PSM1").gameObject.SetActive(false);
            vPSM.transform.Find("PSM2").gameObject.SetActive(false);
        }

        public override void UpdateState(vPSMStateManager vPSM)
        {
            
        }

        public override void ExitState(vPSMStateManager vPSM)
        {
            
        }
    }
}