using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Shooting.Pool
{
    public class RestoreProjectilePoolTrigger:MonoBehaviour
    {
        [SerializeField] private ProjectilePool _pool;
        public event Action ProjectileReturned;
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Projectile projectile) == false)
                return;
            _pool.Return(projectile);
            ProjectileReturned?.Invoke();
            
            
        }
    }
}
