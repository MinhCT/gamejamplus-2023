using States;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    // Start is called before the first frame update
    void Start()
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

    // Update is called once per frame
    void Update()
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
