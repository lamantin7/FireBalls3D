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
    [CreateAssetMenu(fileName = "LevelLostState", menuName = "ScriptableObjects/Game/States/LevelLostState")]
    public class SOLevelLostState:SOGameState
    {
        [SerializeField] private Scene _menu;

        private readonly IAsyncSceneLoading _sceneLoading = new AddressablesSceneLoading();

        public override void Enter()
        {
            _sceneLoading.LoadAsync(_menu);
        }
        public override void Exit() { }
    }
}
