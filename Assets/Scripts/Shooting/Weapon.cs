using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private readonly Transform _shootPoint;
   private readonly Projectile _projilePrefab;
    private readonly float _projectileSpeed;

    public Weapon(Transform shootPoint, Projectile projile, float projectileSpeed)
    {
        _shootPoint = shootPoint;
        _projilePrefab = projile;
        _projectileSpeed = projectileSpeed;
    }
    public void Shoot() =>
        Object
        .Instantiate(_projilePrefab)
        .Shoot(_shootPoint.position, _shootPoint.forward, _projectileSpeed);
        
}
