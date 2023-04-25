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

    [SerializeField] private SOProjectileFactory _projectileFactory;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Projectile projectile) == false)
            return;
        Vector3 hitPoint = collision.contacts[0].point;
    }
}
