using Core;

namespace States
{
    public class MenuState : IState
    {
        private GameStateManager _gameStateManager;

        public MenuState(GameStateManager gameStateManager)
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