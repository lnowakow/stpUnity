using UnityEngine;

namespace Footpedals
{
    public class FootpedalInactiveState : FootpedalBaseState
    {
        public override void EnterState(FootpedalStateManager footpedals)
        {
            Debug.Log("Footpedals in " + footpedals.FootpedalStateString);
        }

        public override void UpdateState(FootpedalStateManager footpedals)
        {
        }

        public override void ExitState(FootpedalStateManager footpedals)
        {
        }
        
    }
}