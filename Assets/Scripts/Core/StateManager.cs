using System;
using UnityEngine;

namespace Core
{
    public class StatesManager
    {
        public enum State
        {
            Menu,
            Game,
            LevelSelecting

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
                    break;
                case State.Game:
                    break;
                case State.LevelSelecting:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public static void ChangeStateToPrevious()
        {
            ChangeState(previousState);
        }
    }
}