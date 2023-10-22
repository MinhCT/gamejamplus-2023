using Core;

namespace UI.Screens
{
    public class PreloaderScreen : Screen
    {

        protected override void Subscribe()
        {
            Events.ApplicationStarted += OnApplicationStarted; 
        }
        protected override void UnSubscribe()
        {
            Events.ApplicationStarted -= OnApplicationStarted; 
        }

        private void OnApplicationStarted()
        {
            HideScreen();
        }
    }
}