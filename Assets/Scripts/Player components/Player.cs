using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerComponents
{


    public class Player : MonoBehaviour
    {
        [SerializeField] private Character _character;
        [SerializeField] private SOshootingPreferences _SOshootingPreferences;

        private FireRate _fireRate;
        private Weapon _weapon;

        private void Start()
        {
            _weapon = _SOshootingPreferences.CreateWeapon(_character.ShootPoint);
            _fireRate = _SOshootingPreferences.CreateFireRate();

            
        }

        public void Shoot() =>
           _fireRate.Shoot(_weapon);

    }
   
}
