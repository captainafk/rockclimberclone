using UniRx;
using UnityEngine;

namespace RockClimber
{
    public class PlayerHangingState : BaseState<EPlayerState>
    {
        [SerializeField] private PlayerInputController _inputController;

        public override EPlayerState GetStateID() => EPlayerState.Hanging;

        private void Awake()
        {
            MessageBus.Receive<OnLevelStarted>().Subscribe(ge =>
            {
                StateManager.SetTransition(EPlayerState.Hanging);
            });

            MessageBus.Receive<OnTargetableReached>().Subscribe(ge =>
            {
                StateManager.SetTransition(EPlayerState.Hanging);
            });
        }

        protected override void OnEnterCustomActions()
        {
            _inputController.EnableInput();
        }

        protected override void OnExitCustomActions()
        {
            _inputController.DisableInput();
        }
    }
}