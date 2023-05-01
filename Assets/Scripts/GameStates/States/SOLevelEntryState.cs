using GameStates.Base;
using SceneLoading;
using UnityEngine;

namespace GameStates.States
{
    [CreateAssetMenu(fileName = "LevelEntryState", menuName = "ScriptableObjects/Game/States/LevelEntryState")]
    public class SOLevelEntryState:SOGameState
    {
        [SerializeField] private Scene _locationScene;
        [SerializeField] private Scene _playerGeneratedPathScene;

        private readonly IAsyncSceneLoading _sceneLoading= new AdressablesSceneLoading();
        public override void Enter()
        {
            _sceneLoading.LoadAsync(_locationScene);
            _sceneLoading.LoadAsync(_playerGeneratedPathScene);

        } 
        public override void Exit()
        {

        }
    }
}
