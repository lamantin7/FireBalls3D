using Levels.Generation;
using SceneLoading;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Levels
{
    [System.Serializable]
    public struct Level
    {
        public Scene LocationScene;
        public SOPathStructure PathStructure;
    }
}
