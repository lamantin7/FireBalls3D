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
    [CreateAssetMenu(fileName = "LevelEntryState", menuName = "ScriptableObjects/Game/States/LevelEntryState")]
    public class SOLevelEntryState:SOGameState
    {
        [SerializeField] private Scene _scene;

        private readonly IAsyncSceneLoading _sceneLoading= new UnitySceneLoading();
        public override void Enter() => 
            _sceneLoading.LoadAsync(_scene);
        public override void Exit()
        {

        }
    }
}
