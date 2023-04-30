using Obstacles;
using Paths;
using Paths.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Levels.Generation
{
    [CreateAssetMenu(fileName = "LevelStructure", menuName = "ScriptableObjects/Levels/LevelStructure")]
    public class SOLevelStructure:ScriptableObject
    {
        [SerializeField] private Path _pathPrefab;
        [SerializeField] private List<PathPlatformStructure> _platforms = new List<PathPlatformStructure>();

        private void OnValidate()
        {
            if (_pathPrefab is null)
                return;

            for (int i = _platforms.Count; i < _pathPrefab.Segments.Count; i++)
                _platforms.Add(default);           
            
        }

        public Path CreatePath(Transform pathToot, ObstacleCollisionFeedback feedback)
        {
            Path path = Instantiate(_pathPrefab, pathToot);
            path.Initialize(_platforms, feedback);

            return path;
        }
    }
}
