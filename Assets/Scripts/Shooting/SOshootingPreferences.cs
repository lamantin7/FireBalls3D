using Shooting.Pool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shooting
{
    [CreateAssetMenu(fileName = "shootingPreferences", menuName = "ScriptableObjects/Shooting/Preferences")]
    public class SOShootingPreferences : ScriptableObject
    {
        [Header("Projectile")]
        [SerializeField] private SOProjectileFactory _projectileFactory;
        [SerializeField][Min(0.0f)] private float _projectileSpeed;
        [SerializeField][Min(0.0f)] private float _fireRate;

        public SOProjectileFactory ProjectileFactory => _projectileFactory;
        public float ProjectileSpeed => _projectileSpeed;
        public float FireRate => _fireRate;

    }
}