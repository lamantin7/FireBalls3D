using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace GameStates.Base
{
    public abstract class SOGameState : ScriptableObject, IGameState
    {
        public virtual void Enter()
        {
            
        }

        public virtual void Exit()
        {
            
        }
    }
}
