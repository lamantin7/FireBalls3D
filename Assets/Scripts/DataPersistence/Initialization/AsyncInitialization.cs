using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace DataPersistence.Initialization
{
    public abstract class AsyncInitialization:MonoBehaviour
    {
        public abstract Task InitializeAsync();
    }
}
