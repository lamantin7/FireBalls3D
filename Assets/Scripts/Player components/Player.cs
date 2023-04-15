using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerComponents
{


    public class Player : MonoBehaviour
    {
        [SerializeField] private Projectile _projectile;
        [SerializeField] private Character _character;
        [SerializeField] private float _projectileSpeed;
        [SerializeField] private float _rate;

        private FireRate _fireRate;

        private void Start()
        {
           _fireRate=new FireRate(_rate, new Weapon(_character.ShootPoint,_projectile, _projectileSpeed));

            
        }

        public void Shoot() =>
           _fireRate.Shoot();

    }
   
}
