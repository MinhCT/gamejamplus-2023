using System;
using Core;

namespace States
{
    public class LevelSelectingState : IState
    {
        private GameStateManager _gameStateManager;

        public LevelSelectingState(GameStateManager gameStateManager)
        {
            _gameStateManager = gameStateManager;
        }
        public static event Action EnterLevelSelectingState;
        public static event Action ExitLevelSelectingState;
        
        public void Tick()
        {
        }

        public void OnEnter()
        {
            EnterLevelSelectingState?.Invoke();
        }

        public void OnExit()
        {
            ExitLevelSelectingState?.Invoke();
        }
    }
}