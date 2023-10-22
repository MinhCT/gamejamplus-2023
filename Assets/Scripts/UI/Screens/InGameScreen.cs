using System;
using System.Collections.Generic;
using Core;
using TMPro;
using UI.MIcs;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Screens
{
    public class InGameScreen : Screen
    {
        [SerializeField] private List<Heart> hearts;
        [SerializeField] private Slider progress;
        [SerializeField] private TMP_Text level;
        
        protected override void Subscribe()
        {
            Events.InGameStateChanged += OnInGameStateChanged;
        }
        protected override void UnSubscribe()
        {
            Events.InGameStateChanged += OnInGameStateChanged;
        }

        private void OnInGameStateChanged()
        {
            ShowScreen();
            AudioManager.Instance.PlaySFXLoop("Muoi");
        }


        private void OnDisable()
        {
            AudioManager.Instance.sfxLoopSource.Pause();
        }

        public void SetProgress(float value)
        {
            progress.value = value;
        }
    }
}
