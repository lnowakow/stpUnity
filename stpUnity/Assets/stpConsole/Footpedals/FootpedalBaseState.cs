namespace Footpedals
{
    public abstract class FootpedalBaseState
    {
        public abstract void EnterState(FootpedalStateManager footpedals);
        public abstract void UpdateState(FootpedalStateManager footpedals);
        public abstract void ExitState(FootpedalStateManager footpedals);
    }
}