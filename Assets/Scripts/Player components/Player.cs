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

        private Weapon _weapon;

        private void Start()
        {
            _weapon = new Weapon(_character.ShootPoint, _projectile, _projectileSpeed);
            
        }

        public void Shoot() =>
           _weapon.Shoot();

    }
   
}
