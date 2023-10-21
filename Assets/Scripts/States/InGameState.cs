using Core;

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
            var currentLevel = _gameStateManager.GetCurrentLevel();
            
            // Load current level here
            
        }

        public void OnExit()
        {
        }
    }
}