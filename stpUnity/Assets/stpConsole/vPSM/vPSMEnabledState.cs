namespace stpConsole.vPSM
{
    public class vPSMEnabledState : vPSMBaseState
    {
        public override void EnterState(vPSMStateManager vPSM)
        {
            vPSM.currentStateString = "EnabledState";
            vPSM.transform.Find("PSM1").gameObject.SetActive(true);
            vPSM.transform.Find("PSM2").gameObject.SetActive(true);
        }

        public override void UpdateState(vPSMStateManager vPSM)
        {
        }

        public override void ExitState(vPSMStateManager vPSM)
        {
        }
    }
}