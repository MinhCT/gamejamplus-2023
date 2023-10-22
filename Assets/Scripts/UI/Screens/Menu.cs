using Core;

namespace UI.Screens
{
    public class Menu : Screen
    {
        protected override void Subscribe()
        {
            Events.MenuStateChanged += OnMenuStateChanged;
        }
        protected override void UnSubscribe()
        {
            Events.MenuStateChanged -= OnMenuStateChanged;
        }

        private void OnMenuStateChanged()
        {
            ShowScreen();
        }
        

        public void OnClickButtonPlay()
        {
            StatesManager.ChangeState(StatesManager.State.InGame);
        }
    }
}