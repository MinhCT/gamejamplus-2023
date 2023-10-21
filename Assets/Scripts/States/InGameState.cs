namespace States
{
    public class InGameState : IState
    {
        private GameStateManager _gameStateManager;

        public InGameState(GameStateManager gameStateManager)
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