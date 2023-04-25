using Factory;

using UnityEngine;

namespace Shooting.Pool
{
    [CreateAssetMenu(fileName = "ProjectileFactory", menuName = "ScriptableObjects/Shooting/ProjectileFactory")]
    public class SOProjectileFactory : ScriptableObject, IFactory<Projectile>
    {
        [SerializeField] private Projectile _projectilePrefab;
        public Projectile Create() => Instantiate(_projectilePrefab);
        
    }
}
