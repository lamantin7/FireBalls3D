using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Levels
{
    [CreateAssetMenu(fileName = "LevelStorage", menuName = "ScriptableObjects/Levels/LevelStorage")]
    public class SOLevelStorage:ScriptableObject
    {
        [SerializeField] private Level[] _levels=Array.Empty<Level>();
        public IReadOnlyList<Level> Levels=> _levels;
    }
}
