using Levels.Generation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Levels.Generation
{
    [CreateAssetMenu(fileName = "PathStructureContainer", menuName = "ScriptableObjects/Levels/PathStructureContainer")]
    internal class SOPathStructureContainer:ScriptableObject
    {
        public SOPathStructure PathStructure { get; set; }
    }
}
