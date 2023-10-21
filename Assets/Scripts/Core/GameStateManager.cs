using System;
using States;
using UnityEngine;

namespace Core
{
    public class GameStateManager : MonoBehaviour
    {
        public static GameStateManager Instance;

        private StateMachine _stateMachineManager = new();

        private bool _btnSelectLevelClicked;
        private bool _hasLevelSelected;
        private bool _hasGameFinished;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(this);
            } else
            {
                Instance = this;
                DontDestroyOnLoad(Instance);
            }
        }

        private void Start()
        {
            var menuState = new MenuState(this);
            var inGameState = new InGameState(this);
            var levelSelectState = new LevelSelectingState(this);

            AddTran(menuState, levelSelectState, () => _btnSelectLevelClicked);
            AddTran(levelSelectState, inGameState, () => _hasLevelSelected);
            AddTran(inGameState, menuState, () => _hasGameFinished);

            return;
            void AddTran(IState from, IState to, Func<bool> cond) => _stateMachineManager.AddTransition(from, to, cond);
        }

        private void Update()
        {
            _stateMachineManager.Tick();
        }

        public void BtnSelectLevelOnClick(string levelName)
        {
            // Do something
            _btnSelectLevelClicked = true;
        }

        public void ChangeLevel()
        {

        }
    }
}
