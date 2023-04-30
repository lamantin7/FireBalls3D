using Paths;
using Shooting;
using Shooting.Pool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Players
{

    public class Player : MonoBehaviour
    {
        [Header("Characteres")]
        [SerializeField] private SOCharacterContainer _characterContainer;

        

        [ Header("Shooting")]
        [SerializeField] private SOShootingPreferences _shootingPreferences;
        [SerializeField] private ProjectilePool _projectilePool;
                
        private FireRate _fireRate;
        private Weapon _weapon;
        

        private void Start()
        {
            Character character = _characterContainer.Create(transform);
            _projectilePool.Initialize(_shootingPreferences.ProjectileFactory);
            _projectilePool.Prewarm(20);

            _weapon = new Weapon (character.ShootPoint,_projectilePool,_shootingPreferences.ProjectileSpeed);
            _fireRate = new FireRate(_shootingPreferences.FireRate);
            
                        
        }

        public void Shoot() =>
           _fireRate.Shoot(_weapon);
        
       

      

    }
   
}
