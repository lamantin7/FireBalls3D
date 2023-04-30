using Obstacles;
using Paths;
using Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Levels.Generation
{
    public class LevelBuilder
    {
        [Header("Path")]
        [SerializeField] private Transform _pathRoot;
        [SerializeField] private SOLevelStructure _structure;

        [Header("Player")]
        [SerializeField] private PlayerMovement _PlayerMovement;
        [SerializeField] private ObstacleCollisionFeedback _obstacleCollisionFeedback;

        private void Start() =>
            Build();

        private void Build()
        {
            Path path= _structure.CreatePath(_pathRoot, _obstacleCollisionFeedback);
            Vector3 initialPosition = path.Segments[0].WayPoints[0].position;

            _PlayerMovement.StartMovingOn(path, initialPosition);
        }
    }
}
