using System;
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

        public static event Action<GameStateManager> EnterInGameState;
        public static event Action ExitInGameState;

        public void Tick()
        {
        }

        public void OnEnter()
        {
            // var currentLevel = _gameStateManager.GetCurrentLevel();
            EnterInGameState?.Invoke(_gameStateManager);
        }

        public void OnExit()
        {
            ExitInGameState?.Invoke();
        }
    }
}