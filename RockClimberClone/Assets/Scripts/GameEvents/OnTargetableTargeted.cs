using UnityEngine;

namespace RockClimber
{
    public class OnTargetableTargeted : GameEventBase
    {
        public Transform Target;

        public OnTargetableTargeted(Transform target)
        {
            Target = target;
        }
    }
}