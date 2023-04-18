using Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Pool
{
    public class MonoComponentPool<T>:MonoBehaviour, IPool<T>where T : Component
    {
        [SerializeField] private Transform _root;
        [SerializeField][Min(0)] private int _prewarmedMemberCount;

        private ComponentPool<T> _pool;
        public void Initialize(IFactory<T> factory) =>
            _pool = new ComponentPool<T>(factory, _root);

        public void Prewarm(int capacity) => 
            _pool.Prewarm(_prewarmedMemberCount);

        public T Request()
        {
            return default;
        }

        public void Return(T member)
        {
           
        }
    }
}
