using DataPersistence.Initialization;
using GameStates.Base;
using GameStates.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Infrastructure
{
    public class Bootstrap:MonoBehaviour
    {
        [SerializeField] private AsyncInitialization[] _initializations;
        [SerializeField] private SOGameStateMachine _stateMachine;

        private async void OnEnable()
        {
            IEnumerable<Task> initializations = _initializations.Select(x => x.InitializeAsync());
            await Task.WhenAll(initializations);
            _stateMachine.Enter<SOMenuEntryState>();
        }
    }
}
