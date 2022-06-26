namespace RockClimber
{
    public class PlayerLevelWinState : BaseState<EPlayerState>
    {
        public override EPlayerState GetStateID() => EPlayerState.LevelWin;

        protected override void OnEnterCustomActions()
        {
        }
    }
}