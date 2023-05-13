using IoC;
using Levels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace DataPersistence
{
    public class LevelInitialization:MonoBehaviour
    {
        private void OnEnable()
        {
            Container.Register(new LevelNumber() { Value = 1 });
        }
    }
}
