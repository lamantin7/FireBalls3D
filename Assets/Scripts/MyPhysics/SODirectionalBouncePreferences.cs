using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace MyPhysics
{
    [CreateAssetMenu(fileName = "DirectionalBouncePreferences", menuName = "ScriptableObjects/Physics/DirectionalBouncePreferences")]
    public class SODirectionalBouncePreferences : ScriptableObject
    {
        [SerializeField] private DirectionalBouncePreferences _prefences;
        public DirectionalBouncePreferences Value => _prefences; 
    }
}
