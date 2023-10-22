namespace UI.Popups
{
    public class LosePopup : Popup
    {
        protected override void Subscribe()
        {
            Events.LoseStateChanged += OnLoseStateChanged;
        }

        private void OnLoseStateChanged()
        {
            ShowPopup();
        }

        protected override void UnSubscribe()
        {
            Events.LoseStateChanged += OnLoseStateChanged;
        }
    }
}