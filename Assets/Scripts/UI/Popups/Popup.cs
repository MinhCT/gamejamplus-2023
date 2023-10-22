using UnityEngine;

namespace UI.Popups
{
    public abstract class Popup : MonoBehaviour
    {
        protected virtual void Awake()
        {
            Subscribe();
            HidePopup();
            
            Events.StateChanged += OnStateChanged;
        }


        protected virtual void OnDestroy()
        {
            UnSubscribe();
            Events.StateChanged += OnStateChanged;
        }
        private void OnStateChanged()
        {
HidePopup();        }

        protected abstract void Subscribe();
        protected abstract void UnSubscribe();
        
        public void ShowPopup()
        {
            gameObject.SetActive(true);
        }

        public void HidePopup()
        {
            gameObject.SetActive(false);
        }
    }
}