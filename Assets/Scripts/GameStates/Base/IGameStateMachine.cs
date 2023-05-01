using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStates.Base
{
    public interface IGameStateMachine
    {
        void Enter<TState>() where TState : IGameState;
    }
}
