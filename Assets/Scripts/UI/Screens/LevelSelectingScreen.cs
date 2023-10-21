using Core;
using States;

namespace UI.Screens
{
    public class LevelSelectingScreen : Screen
    {
        private GameStateManager _gameStateManager;

        protected override void Subscribe()
        {
            LevelSelectingState.EnterLevelSelectingState += OnEnterLevelSelectingState;
            LevelSelectingState.ExitLevelSelectingState += OnExitLevelSelectingState;
        }
        protected override void UnSubscribe()
        {
            LevelSelectingState.EnterLevelSelectingState -= OnEnterLevelSelectingState;
            LevelSelectingState.ExitLevelSelectingState -= OnExitLevelSelectingState;
        }

        private void OnExitLevelSelectingState()
        {
            HideScreen();
        }

        private void OnEnterLevelSelectingState(GameStateManager gameStateManager)
        {
            ShowScreen();
            _gameStateManager = gameStateManager;
        }

        public void SelectLevel(int level)
        {
            _gameStateManager?.ChangeLevel(level);
        }

    }
}