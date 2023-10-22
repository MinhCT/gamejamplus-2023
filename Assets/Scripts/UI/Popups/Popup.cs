using UnityEngine;

namespace UI.Popups
{
    public abstract class Popup : MonoBehaviour
    {
        protected virtual void Awake()
        {
            Subscribe();
            HidePopup();
        }

        protected virtual void OnDestroy()
        {
            UnSubscribe();
        }

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