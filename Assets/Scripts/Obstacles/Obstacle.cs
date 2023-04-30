using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Obstacles
{
    public class Obstacle:MonoBehaviour
    {
        [SerializeField] private ObstacleCollision _collision;
        public void Initialize (ObstacleCollisionFeedback feedback) 
        { 
            _collision.Initialize (feedback);
        }

    }
}
