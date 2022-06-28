using UniRx;
using UnityEngine;

namespace RockClimber
{
    public class PlayerMovingState : BaseState<EPlayerState>
    {
        [SerializeField] private PlayerMovementController _movementController;

        private Transform _target;

        public override EPlayerState GetStateID() => EPlayerState.Moving;

        private void Awake()
        {
            MessageBus.Receive<OnTargetableTargeted>().Subscribe(ge =>
            {
                _target = ge.Target;

                StateManager.SetTransition(EPlayerState.Moving);
            });
        }

        protected override void OnEnterCustomActions()
        {
            _movementController.Move(_target.position,
                                     () => MessageBus.Publish(new OnTargetableReached()));
        }
    }
}