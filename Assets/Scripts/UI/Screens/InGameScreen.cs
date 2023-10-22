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
            Events.GameStateChanged += OnGameStateChanged;
        }
        protected override void UnSubscribe()
        {
            Events.GameStateChanged += OnGameStateChanged;
        }

        private void OnGameStateChanged()
        {
            ShowScreen();
        }

        public void SetProgress(float value)
        {
            progress.value = value;
        }
    }
}
