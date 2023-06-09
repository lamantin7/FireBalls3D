﻿using IoC;
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
		
		[Header("Player")] 
		[SerializeField] private PlayerMovement _playerMovement;
		[SerializeField] private ObstacleCollisionFeedback _obstacleCollisionFeedback;

		private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
		
		private void Start() => 
			Build();

		private void OnDisable() => 
			_cancellationTokenSource.Cancel();

		private void Build()
		{
			Path path = Container
				.InstanceOf<PathStructureContainer>()
				.PathStructure
				.CreatePath(_pathRoot, _obstacleCollisionFeedback, _cancellationTokenSource);

			Vector3 initialPosition = path.Segments[0].WayPoints[0].position;

			_playerMovement.StartMovingOn(path, initialPosition, _cancellationTokenSource);
		}
    }
}
