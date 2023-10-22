
namespace UI.Popups
{
    public class WinPopup : Popup
    {
        protected override void Subscribe()
        {
            Events.WinStateChanged += OnWinStateChanged;
        }

        private void OnWinStateChanged()
        {
            ShowPopup();
        }
        
        protected override void UnSubscribe()
        {
            Events.WinStateChanged += OnWinStateChanged;
        }
    }
}
