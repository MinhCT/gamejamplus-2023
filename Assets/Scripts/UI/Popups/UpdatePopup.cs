
namespace UI.Popups
{
    public class UpdatePopup : Popup
    {
        protected override void Subscribe()
        {
            Events.OpenUpdatePopup += OnOpenUpdatePopup;
        }

        private void OnOpenUpdatePopup()
        {
            ShowPopup();
        }

        protected override void UnSubscribe()
        {
            Events.OpenUpdatePopup += OnOpenUpdatePopup;
        }
    }
}
