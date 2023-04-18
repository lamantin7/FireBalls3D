using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "shootingPreferences",menuName ="ScriptableObjects/Shooting/Preferences")]
public class SOshootingPreferences : ScriptableObject
{
    [Header("Projectile")]
    [SerializeField] private Projectile _projectilePrefab;
  
    [SerializeField] [Min(0.0f)]private float _projectileSpeed;
    [SerializeField] [Min(0.0f)]private float _fireRate;

    public Weapon CreateWeapon (Transform shootPoint)=>
        new Weapon (shootPoint, _projectilePrefab, _projectileSpeed);
    public FireRate CreateFireRate() => new FireRate(_fireRate);
   
}
