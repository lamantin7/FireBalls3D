using IoC;
using Levels.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Levels
{
    [CreateAssetMenu(fileName = "CurrentLevel", menuName = "ScriptableObjects/Menu/Level/CurrentLevel")]
    public class SOCurrentLevel : ScriptableObject, ILevelNumberProvider, ILevelProvider,ILevelChanging
    {
        [SerializeField] private SOLevelStorage _storage;
        private LevelNumber LevelNumber=>Container.InstanceOf<LevelNumber>();
        public int Value =>LevelNumber.Value;
        public Level Current => _storage.Levels[LevelNumber.Value-1];

        public void StepToNextLevel()=>
            LevelNumber.Value=Mathf.Clamp(LevelNumber.Value+1,1,_storage.Levels.Count);
        
    }
}
