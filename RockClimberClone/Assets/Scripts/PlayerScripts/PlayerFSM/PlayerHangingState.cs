using UniRx;
using UnityEngine;

namespace RockClimber
{
    public class PlayerHangingState : BaseState<EPlayerState>
    {
        [SerializeField] private PlayerInputController _inputController;

        private System.IDisposable _d1;
        private System.IDisposable _d2;

        public override EPlayerState GetStateID() => EPlayerState.Hanging;

        private void Awake()
        {
            _d1 = MessageBus.Receive<OnLevelStarted>().Subscribe(ge =>
            {
                StateManager.SetTransition(EPlayerState.Hanging);
            });

            _d2 = MessageBus.Receive<OnTargetableReached>().Subscribe(ge =>
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

        private void OnDestroy()
        {
            _d1?.Dispose();
            _d2?.Dispose();
        }
    }
}