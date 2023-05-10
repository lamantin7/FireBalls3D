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
        [SerializeField] private SOLevelNumber _levelNumber;
        public int Value =>_levelNumber.Value;
        public Level Current => _storage.Levels[_levelNumber.Value-1];

        public void StepToNextLevel()=>
            _levelNumber.Value=Mathf.Clamp(_levelNumber.Value+1,1,_storage.Levels.Count);
        
    }
}
