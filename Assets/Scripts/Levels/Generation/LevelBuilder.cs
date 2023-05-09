using Assets.Scripts.Levels.Generation;
using Obstacles;
using Paths;
using Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace Levels.Generation
{
    public class LevelBuilder:MonoBehaviour
    {
        [Header("Path")]
        [SerializeField] private Transform _pathRoot;
        [SerializeField] private SOPathStructureContainer _pathStructureContainer;

        [Header("Player")]
        [SerializeField] private PlayerMovement _PlayerMovement;
        [SerializeField] private ObstacleCollisionFeedback _obstacleCollisionFeedback;

        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        private SOPathStructure PathStructure=>_pathStructureContainer.PathStructure;

        private void Start() =>
            Build();
        private void OnDisable() => 
            _cancellationTokenSource.Cancel();

        private void Build()
        {
            Path path= PathStructure.CreatePath(_pathRoot, _obstacleCollisionFeedback, _cancellationTokenSource);
            Vector3 initialPosition = path.Segments[0].WayPoints[0].position;

            _PlayerMovement.StartMovingOn(path, initialPosition, _cancellationTokenSource);
        }
    }
}
