using GameStates.Base;
using GameStates.States;
using Paths.Completion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paths.Completion
{
    public class LevelPathCompletion : IPathCompletion
    {
        private readonly IGameStateMachine _stateMachine;

        public LevelPathCompletion(IGameStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        public void Complete() =>
            _stateMachine.Enter<LevelCompletedState>();
    }
}
