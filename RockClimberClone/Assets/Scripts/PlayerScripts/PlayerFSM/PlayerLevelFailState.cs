namespace RockClimber
{
    public class PlayerLevelFailState : BaseState<EPlayerState>
    {
        public override EPlayerState GetStateID() => EPlayerState.LevelFail;

        protected override void OnEnterCustomActions()
        {
        }
    }
}