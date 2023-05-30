using Levels.Generation;
using GameStates.Base;
using IoC;
using Levels;
using SceneLoading;
using Tools;
using UnityEngine;
using UnityObject = UnityEngine.Object;

namespace GameStates.States
{
    [CreateAssetMenu(fileName = "LevelEntryState", menuName = "ScriptableObjects/Game/States/LevelEntryState")]
    public class SOLevelEntryState:SOGameState
    {
        //[SerializeField] private Scene _locationScene;
        [SerializeField] private Scene _playerGeneratedPathScene;
        [SerializeField] private UnityObject _levelProvider;
       

        private readonly IAsyncSceneLoading _sceneLoading= new AddressablesSceneLoading();
        private Level Level => LevelProvider.Current;
        private ILevelProvider LevelProvider=>(ILevelProvider) _levelProvider;

        private void OnValidate()
        {
            Inspector.ValidateOn<ILevelProvider>(ref _levelProvider);
        }
        public override async void Enter()
        {
            Container.Register(new PathStructureContainer() { PathStructure=Level.PathStructure});
            
           await _sceneLoading.LoadAsync(Level.LocationScene);
            await _sceneLoading.LoadAsync(_playerGeneratedPathScene);

        } 
        public override void Exit()
        {

        }
    }
}
