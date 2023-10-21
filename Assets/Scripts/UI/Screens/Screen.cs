using System;
using UnityEngine;

namespace UI.Screens
{
    public abstract class Screen : MonoBehaviour
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