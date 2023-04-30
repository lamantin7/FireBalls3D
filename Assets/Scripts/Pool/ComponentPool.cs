using Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor.Search;
using UnityEngine;

namespace Pool
{
    public class ComponentPool<T> : IPool<T> where T : Component
    {
        private readonly Stack<T> _availableMembers = new Stack<T>();
        private readonly IFactory<T> _factory;
        private readonly Transform _root;

        private readonly int _initialCapacity;

        public ComponentPool(IFactory<T> factory, Transform root, int intialcapacity)
        {
            
            _factory = factory;
            _root = root;
            if (intialcapacity < 0)
                throw new ArgumentException("saa");
            _initialCapacity = intialcapacity;

            
        }

        public void Prewarm()
        {
            for (int i = 0; i < _initialCapacity; i++)
            {
                T member = _factory.Create();
                Setup(member);
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
        private void Setup(T member)
        {
            member.transform.SetParent(_root);
            member.gameObject.SetActive(false);
        }
        
        private void Show(T member) => 
            member.gameObject.SetActive(true);
    }
}
