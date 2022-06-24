using UniRx;
using UnityEngine;
using Lean.Touch;

namespace RockClimber
{
    public class PlayerInputController : MonoBehaviour
    {
        [SerializeField] private LayerMask _targetableLayer;

        private void Awake()
        {
            MessageBus.Receive<OnLevelStarted>()
                      .Subscribe(ge => EnableInput());
        }

        private void EnableInput() => LeanTouch.OnFingerDown += HandleInput;

        private void DisableInput() => LeanTouch.OnFingerDown -= HandleInput;

        private void HandleInput(LeanFinger finger)
        {
            var ray = finger.GetRay();
            if (Physics.Raycast(ray, 100, _targetableLayer))
            {
                print("Nice!");
            }
        }

        // Temporary - for debugging purposes
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                MessageBus.Publish(new OnLevelStarted());
                print("Game Started");
            }
        }
    }
}