using UnityEngine;

namespace UI.Popups
{
    public abstract class Popup : MonoBehaviour
    {
        private void Awake()
        {
            Subscribe();
        }

        private void OnDestroy()
        {
            UnSubscribe();
        }

        protected abstract void Subscribe();
        protected abstract void UnSubscribe();
    }
}