using Lean.Touch;
using UnityEngine;

namespace RockClimber
{
    public class PlayerInputController : MonoBehaviour
    {
        [SerializeField] private LayerMask _targetableLayer;

        public void EnableInput() => LeanTouch.OnFingerDown += HandleInput;

        public void DisableInput() => LeanTouch.OnFingerDown -= HandleInput;

        private void HandleInput(LeanFinger finger)
        {
            var ray = finger.GetRay();
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100, _targetableLayer))
            {
                MessageBus.Publish(new OnTargetableTargeted(hit.transform));
            }
        }
    }
}