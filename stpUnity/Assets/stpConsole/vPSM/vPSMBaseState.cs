namespace stpConsole.vPSM
{
    public abstract class vPSMBaseState
    {
        public abstract void EnterState(vPSMStateManager vPSM);
        public abstract void UpdateState(vPSMStateManager vPSM);
        public abstract void ExitState(vPSMStateManager vPSM);
    }
}