using GameStates.Base;
using SceneLoading;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace GameStates.States
{
    [CreateAssetMenu(fileName = "MenuEntryState", menuName = "ScriptableObjects/Game/States/MenuEntryState")]
    public class SOMenuEntryState : SOGameState
    {
        [SerializeField] private Scene _menu;

        private readonly IAsyncSceneLoading _sceneLoading=new AddressablesSceneLoading();

        public override void Enter()
        {
            _sceneLoading.LoadAsync(_menu);
        }
        public override void Exit() { }

    }
}
