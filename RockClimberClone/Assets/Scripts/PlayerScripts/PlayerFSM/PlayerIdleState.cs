using Lean.Touch;

namespace RockClimber
{
    public class PlayerIdleState : BaseState<EPlayerState>
    {
        public override EPlayerState GetStateID() => EPlayerState.Idle;

        protected override void OnEnterCustomActions()
        {
            LeanTouch.OnFingerDown += HandleFirstTap;
        }

        private void HandleFirstTap(LeanFinger finger)
        {
            LeanTouch.OnFingerDown -= HandleFirstTap;

            MessageBus.Publish(new OnLevelStarted());
            print("Game Started");
        }
    }
}