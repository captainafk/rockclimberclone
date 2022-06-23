namespace RockClimber
{
    public class OnLevelFinished : GameEventBase
    {
        public bool IsLevelSuccessful;

        public OnLevelFinished(bool isLevelSuccessful)
        {
            IsLevelSuccessful = isLevelSuccessful;
        }
    }
}