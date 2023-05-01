using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStates.Base
{
    public class GameStateMachine:IGameStateMachine
    {
        private readonly Dictionary<Type, IGameState> _states;
        private IGameState _currentState = new IGameState.Empty();

        public GameStateMachine (IEnumerable<IGameState> states) : this(CreateStatesFrom(states)) { }

        public GameStateMachine(Dictionary<Type, IGameState> states)
        {
            _states = states;
        }

        public void Enter<TState>() where TState : IGameState
        {
            if (_states.TryGetValue(typeof(TState), out IGameState newState) == false)
                throw new InvalidOperationException("Trying to enter unregistered");

            _currentState.Exit();
            _currentState = newState;
            _currentState.Enter();
        }

        private static Dictionary<Type, IGameState> CreateStatesFrom(IEnumerable<IGameState> states)
        {
            var createdStates= new Dictionary<Type, IGameState>();

            foreach (IGameState state in states)
            {
                Type stateKey = state.GetType();
                createdStates.Add(stateKey, state);
            }
            return createdStates;
        }
    }
}
