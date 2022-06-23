using System;
using UnityEngine;

namespace RockClimber
{
    public abstract class BaseState<T> : MonoBehaviour where T : Enum
    {
        [SerializeField] private StateManager<T> _stateManager;

        public StateManager<T> StateManager => _stateManager;

        public abstract T GetStateID();

        public abstract void OnEnterCustomActions();

        public abstract void OnExitCustomActions();

        public void OnEnterActions()
        {
            OnEnterCustomActions();
        }

        public void OnExitActions()
        {
            OnExitCustomActions();
        }
    }
}