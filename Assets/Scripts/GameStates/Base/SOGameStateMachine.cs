using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace GameStates.Base
{
    [CreateAssetMenu(fileName = "GameStateMachine", menuName = "ScriptableObjects/Game/StateMachine")]
    public class SOGameStateMachine:ScriptableObject, IGameStateMachine
    {
        [SerializeField] private SOGameState[] _states;

        private GameStateMachine _stateMachine;


        private void OnEnable() =>
            _stateMachine = new GameStateMachine(_states);
        public void Enter<TState>() where TState : IGameState => 
            _stateMachine.Enter<TState>();
    }
}
