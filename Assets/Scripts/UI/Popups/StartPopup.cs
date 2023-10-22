
using Core;

namespace UI.Popups
{
    public class StartPopup : Popup
    {
        protected override void Subscribe()
        {
            Events.StartStateChanged += OnStartStateChanged;
        }

        protected override void UnSubscribe()
        {
            Events.StartStateChanged += OnStartStateChanged;
        }

        private void OnStartStateChanged()
        {
            ShowPopup();
            
            Invoke("ToGamePlay",2f);
        }


        void ToGamePlay()
        {
            StatesManager.ChangeState(StatesManager.State.InGame);
        }
    }
}
