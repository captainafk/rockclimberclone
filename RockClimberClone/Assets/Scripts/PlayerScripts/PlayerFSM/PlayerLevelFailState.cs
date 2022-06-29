using UniRx;
using UnityEngine;

namespace RockClimber
{
    public class PlayerLevelFailState : BaseState<EPlayerState>
    {
        [SerializeField] private PlayerMovementController _movementController;

        private System.IDisposable _d1;

        public override EPlayerState GetStateID() => EPlayerState.LevelFail;

        private void Awake()
        {
            _d1 = MessageBus.Receive<OnLevelFinished>().Subscribe(ge =>
            {
                if (!ge.IsLevelSuccessful)
                {
                    StateManager.SetTransition(EPlayerState.LevelFail);
                }
            });
        }

        protected override void OnEnterCustomActions()
        {
            _movementController.StopMovement();
        }

        private void OnDestroy()
        {
            _d1?.Dispose();
        }
    }
}