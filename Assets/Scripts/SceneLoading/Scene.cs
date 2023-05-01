using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace SceneLoading
{
    [System.Serializable]
    public struct Scene
    {
        public string Name;
        public LoadSceneMode LoadMode;
    }
}
