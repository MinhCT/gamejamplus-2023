using System;
using UnityEngine;

namespace Core
{
    public abstract class StatesManager
    {
        public enum State
        {
            Menu,
            InGame,
            Start,
            Lose,
            Win,
            LevelSelecting,
        }

        public static State currentState;
        public static State previousState;

        public static void ChangeState(State state)
        {
            previousState = currentState;

            Debug.Log("CHANGE STATE : " + previousState + " -> " + state);
            currentState = state;

            Events.OnStateChanged();

            switch (currentState)
            {
                case State.Menu:
                    Events.OnMenuStateChanged();
                    break;
                case State.InGame:
                    Events.OnInGameStateChanged();
                    break;
                case State.LevelSelecting:
                    break;
                case State.Start:
                    Events.OnStartStateChanged();
                    break;
                case State.Lose: 
                    Events.OnLoseStateChanged();
                    break;
                case State.Win: 
                    Events.OnWinStateChanged();
                    break;
                default:
                    break;
            }
        }

        public static void ChangeStateToPrevious()
        {
            ChangeState(previousState);
        }
    }
}