using Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Pool
{
    public abstract class MonoComponentPool<T> : MonoBehaviour, IPool<T> where T : Component
    {
        [SerializeField] private Transform _root;
        [SerializeField] [Min(0)] private int _prewarmedMemeberCount;
        
        private ComponentPool<T> _pool;
        public void Initialize(IFactory<T> factory /*int capacity*/)=>        
            _pool = new ComponentPool<T>(factory, _root,_prewarmedMemeberCount);
        //_pool.Prewarm(capacity);

        public void Prewarm() => 
            _pool.Prewarm();

        public T Request() => 
            _pool.Request();

        public void Return(T member)=>
            _pool.Return(member);
        public void Enable()=>gameObject.SetActive(true);
        public void Disable()=> gameObject.SetActive(false);
     
    }
}
