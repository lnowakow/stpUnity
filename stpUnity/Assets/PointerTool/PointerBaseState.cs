namespace PointerTool
{
    public abstract class PointerBaseState
    {
        public abstract void EnterState(PointerStateManager pointer);
        public abstract void UpdateState(PointerStateManager pointer);
        public abstract void ExitState(PointerStateManager pointer);
    }
}