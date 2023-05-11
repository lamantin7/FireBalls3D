using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateMachine
{
    public class ButtonStateMachine : MonoBehaviour
    {
        [SerializeField] private MonoState[] _states=Array.Empty<MonoState>();
        [SerializeField] private string _key;
        private int _currentStateIndex;
        private void Start() => 
            Initialize();
        public void ChangeOnNextState()
        {
            _currentStateIndex = GetNextStateIndex(_currentStateIndex);
            PlayerPrefs.SetInt(_key, _currentStateIndex);
            _states[_currentStateIndex].Enter();
        }
        private void Initialize()
        {
            if (_states.Length==0)
            {
                enabled = false;
                throw new InvalidOperationException("States should be initialized");

            }
            
            _currentStateIndex = PlayerPrefs.GetInt(_key,0);
            _states[_currentStateIndex].Enter();
        }
        private int GetNextStateIndex(int currentIndex)=>
            (currentIndex+1)%_states.Length;
    }
}
