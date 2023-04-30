using Obstacles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Towers.Generation;

namespace Paths.Builders
{
    [System.Serializable]
    public struct PathPlatformStructure
    {
        public SOTowerStructure TowerStructure;
        public Obstacle[] Obstacles;
    }
}
