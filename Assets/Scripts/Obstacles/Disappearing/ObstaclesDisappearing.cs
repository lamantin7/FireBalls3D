﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tweening;
using UnityEngine;
using UnityObject = UnityEngine.Object;

namespace Obstacles.Disappearing
{
    public class ObstaclesDisappearing
    {
        private readonly Transform _obstaclesRoot;
        private readonly IEnumerable<Obstacle> _obstacles;
        private readonly IAwaitableTweenAnimation _animation;

        public ObstaclesDisappearing(Transform obstaclesRoot, IEnumerable<Obstacle> obstacles, IAwaitableTweenAnimation animation)
        {
            _obstaclesRoot = obstaclesRoot;
            _obstacles = obstacles;
            _animation = animation;
        }
        public async Task ApplyAsync()
        {
            await _animation.ApplyTo(_obstaclesRoot);
            foreach (Obstacle obstacle in _obstacles)
                UnityObject.Destroy(obstacle.gameObject);
            await Task.CompletedTask;
        }
    }
}
