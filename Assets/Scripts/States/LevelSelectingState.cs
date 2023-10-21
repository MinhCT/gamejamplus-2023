namespace States
{
    public class LevelSelectingState : IState
    {

        private GameStateManager _gameStateManager;

        public LevelSelectingState(GameStateManager gameStateManager)
        {
            _gameStateManager = gameStateManager;
        }

        public void Tick()
        {
        }

        public void OnEnter()
        {
        }

        public void OnExit()
        {
        }
    }
}