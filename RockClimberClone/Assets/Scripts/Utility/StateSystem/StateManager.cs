using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace RockClimber
{
    public class StateManager<T> : MonoBehaviour where T : Enum
    {
        [SerializeField] private T _initialStateID;

        private List<BaseState<T>> _states;
        private BaseState<T> _currentState;
        private Dictionary<T, BaseState<T>> _stateByID = new Dictionary<T, BaseState<T>>();

        private void Awake()
        {
            _states = GetComponentsInChildren<BaseState<T>>().ToList();

            _states.ForEach(s => _stateByID.Add(s.GetStateID(), s));

            _currentState = _stateByID[_initialStateID];

            _currentState.OnEnterActions();
        }

        public void SetTransition(T toStateID)
        {
            _currentState.OnExitActions();

            var toState = _stateByID[toStateID];
            toState.OnEnterActions();

            _currentState = toState;
        }

        public T GetCurrentStateID() => _currentState.GetStateID();
    }
}