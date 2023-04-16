using Factory;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Component = UnityEngine.Component;

namespace Pool
{
    public class ComponentPool<T> : IPool<T> where T : Component
    {
        private readonly Stack<T> _availableMembers = new Stack<T> ();
        private readonly IFactory<T> _factory;
        private readonly Transform _root;

        public ComponentPool(IFactory<T> factory, Transform root)
        {
            _factory = factory;
            _root = root;
        }

        public void Prewarm(int capacity)
        {
            for(int i = 0; i < capacity; i++)
            {
                T member = _factory.Create();
                _availableMembers.Push(member);
            }
        }

        public T Request()
        {
            T member;
            if (_availableMembers.Count>0)
            {
                member = _availableMembers.Pop();
            }
            else
            {
                member = _factory.Create();
                Setup(member);
            }
            Show(member); 
            return member;
        }

        public void Return(T member)
        {
            _availableMembers.Push(member);
            Setup(member);
        }
        private void Setup (T member)
        {
            member.transform.SetParent(_root);
            member.gameObject.SetActive(false);
        }
        private void Show(T member)=>
            member.gameObject.SetActive(true);
    }
}
