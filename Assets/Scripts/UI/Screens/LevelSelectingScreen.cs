using States;

namespace UI.Screens
{
    public class LevelSelectingScreen : Screen
    {
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

        private void OnEnterLevelSelectingState()
        {
            ShowScreen();
        }

    }
}