using System;
using UnityEngine;

namespace RockClimber
{
    public abstract class BaseState<T> : MonoBehaviour where T : Enum
    {
        [SerializeField] private StateManager<T> _stateManager;

        public StateManager<T> StateManager => _stateManager;

        public abstract T GetStateID();

        protected abstract void OnEnterCustomActions();

        protected virtual void OnExitCustomActions()
        {
        }

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