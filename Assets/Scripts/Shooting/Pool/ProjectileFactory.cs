

using Factory;
using UnityEngine;

namespace Pool
{
    [CreateAssetMenu(fileName ="ProjectileFactory", menuName ="ScriptableObjects/Shooting/ProjectileFactory")]
    public class ProjectileFactory:ScriptableObject,IFactory<Projectile>
    {
        [SerializeField] private Projectile _projectilePrefab;

        public Projectile Create() =>
            Instantiate(_projectilePrefab);
    }
}
