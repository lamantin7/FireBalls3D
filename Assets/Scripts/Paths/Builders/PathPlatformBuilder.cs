using Obstacles;
using Obstacles.Disappearing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Towers.Disassembling;
using UnityEngine;

namespace Paths.Builders
{
    public class PathPlatformBuilder
    {
        [SerializeField] private PathTowerBuilder _towerBuilder;
        [SerializeField] private PathObstaclesBuilder _obstaclesBuilder;

        private ObstacleCollisionFeedback _obstacleCollisionFeedback;

        public void Initialize(PathPlatformStructure pathPlatformStructure, ObstacleCollisionFeedback collisionFeedback)
        {
            _towerBuilder.Initialize(pathPlatformStructure.TowerStructure);
            _obstaclesBuilder.Initialize(pathPlatformStructure.Obstacles);
            _obstacleCollisionFeedback = collisionFeedback;
        }
        
        public async Task<(TowerDisassembling, ObstaclesDisappearing)> BuildAsync()
        {
            TowerDisassembling disassembling = await _towerBuilder.BuildAsync(_obstacleCollisionFeedback.PlayerProjectilePool);
            ObstaclesDisappearing disappearing = _obstaclesBuilder.Build(_obstacleCollisionFeedback);

            return(disassembling, disappearing);
        }
    }
}
