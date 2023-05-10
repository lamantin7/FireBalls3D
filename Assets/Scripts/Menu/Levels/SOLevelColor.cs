using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Menu.Levels
{
    [CreateAssetMenu(fileName = "LevelColors", menuName = "ScriptableObjects/Menu/Level/Colors")]
    public class SOLevelColor:ScriptableObject
    {
        [SerializeField] private Color _passedLevels = Color.green;
        [SerializeField] private Color _nextLevels=Color.white;

        public Color PassedLevels=> _passedLevels;
        public Color NextLevels => _nextLevels;
    }
}
