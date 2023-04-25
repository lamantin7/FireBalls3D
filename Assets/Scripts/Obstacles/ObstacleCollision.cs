using Coroutines;
using MyPhysics;
using PlayerComponents;
using Shooting.Pool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCollision : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private PlayerInputHandler _playerInputHandler;
    [SerializeField] private ProjectilePool _pool;
    [SerializeField] private SODirectionalBouncePreferences _bouncePreferences;

    [SerializeField] private SOProjectileFactory _projectileFactory;

    private bool _hasAlreadyCollided;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Projectile projectile) == false)
            return;
        if (_hasAlreadyCollided)
            return;
        _hasAlreadyCollided = true;

        _hasAlreadyCollided = true;
        _pool.Return(projectile);
        _playerInputHandler.Disable();
        _pool.Disable();
        Vector3 hitPoint = collision.contacts[0].point;

        Projectile playerHitProjectile = _projectileFactory.Create();

        new DirectionalBounce(playerHitProjectile.transform,
            new CoroutineExecutor(playerHitProjectile),
            _bouncePreferences.Value)
            .BounceTo(_player.position, hitPoint);
    }
}
