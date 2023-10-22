using System;
using UnityEngine;

namespace UI.Screens
{
    public abstract class Screen : MonoBehaviour
    {
        protected virtual void Awake()
        {
            Subscribe();
            Events.StateChanged += OnStateChanged;
        }

        protected virtual void OnDestroy()
        {
            UnSubscribe();
            Events.StateChanged -= OnStateChanged;
        }

        private void OnStateChanged()
        {
            HideScreen();
        }

        protected abstract void Subscribe();
        protected abstract void UnSubscribe();

        public void ShowScreen()
        {
            gameObject.SetActive(true);
        }

        public void HideScreen()
        {
            gameObject.SetActive(false);
        }
    }
}