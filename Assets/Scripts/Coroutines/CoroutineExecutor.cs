using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Coroutines
{
    public class CoroutineExecutor
    {
        private readonly MonoBehaviour _executor;
        public CoroutineExecutor(MonoBehaviour executor)
        {
            _executor = executor;
        }
        public Coroutine Start(IEnumerator coroutine)=>
            _executor.StartCoroutine(coroutine);
        public void Stop(Coroutine coroutine)=>
            _executor.StopCoroutine(coroutine);
    }
}
