using Coroutines;
using MyPhysics;
using Players;
using Shooting.Pool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Obstacles
{
    [System.Serializable]
    public struct ObstacleCollisionFeedback
    {
        public Transform Player;
        public PlayerInputHandler PlayerInputHandler;
        public ProjectilePool PlayerProjectilePool;
    }
    public class ObstacleCollision : MonoBehaviour
    {

        [SerializeField] private SOProjectileFactory _projectileFactory;
        [SerializeField] private SODirectionalBouncePreferences _bouncePreferences;
               
        private bool _hasAlreadyCollided;
        private ObstacleCollisionFeedback _obstacleCollisionFeedback;

        public void Initialize(ObstacleCollisionFeedback feedback)
        {
            _obstacleCollisionFeedback = feedback;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent(out Projectile projectile) == false)
                return;
            if (_hasAlreadyCollided)
                return;

            _hasAlreadyCollided = true;


            _obstacleCollisionFeedback.PlayerProjectilePool.Return(projectile);
            _obstacleCollisionFeedback.PlayerInputHandler.Disable();
            _obstacleCollisionFeedback.PlayerProjectilePool.Disable();
            Vector3 hitPoint = collision.contacts[0].point;

            Projectile playerHitProjectile = _projectileFactory.Create();

            new DirectionalBounce(playerHitProjectile.transform,
                new CoroutineExecutor(playerHitProjectile),
                _bouncePreferences.Value)
                .BounceTo(_obstacleCollisionFeedback.Player.position, hitPoint);
        }
    }
}