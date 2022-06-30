using System;
using Pathfinding;
namespace My2DPlatformer
{
    public class AIPatrolPath : AIPath
    {
        public Action TargetReached;

        public override void OnTargetReached()
        {
            base.OnTargetReached();
            DispatchTargetReached();
        }

        protected virtual void DispatchTargetReached()
        {
            TargetReached?.Invoke();
        }
    }
}