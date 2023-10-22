
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
            Events.OpenUpdatePopup += OnOpenUpdatePopup;
        }

        protected override void UnSubscribe()
        {
            
        }
    }
}
