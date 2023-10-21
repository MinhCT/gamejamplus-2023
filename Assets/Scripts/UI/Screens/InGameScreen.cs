using System.Collections.Generic;
using Core;
using States;
using TMPro;
using UI.MIcs;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Screens
{
    public class InGameScreen : Screen
    {
        private GameStateManager _gameStateManager;
        [SerializeField] private List<Heart> hearts;
        [SerializeField] private Slider progress;
        [SerializeField] private TMP_Text level;
        
        protected override void Subscribe()
        {
            InGameState.EnterInGameState += OnEnterInGameState;
            InGameState.ExitInGameState += OnExitInGameState;
        }
        protected override void UnSubscribe()
        {
            InGameState.EnterInGameState -= OnEnterInGameState;
            InGameState.ExitInGameState -= OnExitInGameState;
        }


        private void OnEnterInGameState(GameStateManager obj)
        {
            ShowScreen();
            _gameStateManager = obj;
            
        }

        private void OnExitInGameState()
        {
            HideScreen();
        }
        
        public void SetProgress(float value)
        {
            progress.value = value;
        }
    }
}
