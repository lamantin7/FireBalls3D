using GameStates.Base;
using Levels.Interfaces;
using SceneLoading;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools;
using UnityEngine;
using UnityObject = UnityEngine.Object;

namespace GameStates.States
{
    [CreateAssetMenu(fileName = "LevelCompletedState", menuName = "ScriptableObjects/Game/States/LevelCompletedState")]
    public class LevelCompletedState:SOGameState
    {
        [SerializeField] private Scene _menu;
        [SerializeField] private UnityObject _levelChanging;

        private readonly IAsyncSceneLoading _sceneLoading = new AdressablesSceneLoading();

        private ILevelChanging LevelChanging=>(ILevelChanging)_levelChanging;

        private void OnValidate() => 
            Inspector.ValidateOn<ILevelChanging>(ref _levelChanging);
        public override async void Enter()
        {
            LevelChanging.StepToNextLevel();
            await _sceneLoading.LoadAsync(_menu);
        }
        public override void Exit()
        {

        }
    }
}
