using Paths;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerComponents
{


    public class Player : MonoBehaviour
    {
        [SerializeField] private Character _character;
        [SerializeField] private SOshootingPreferences _shootingPreferences;

        [SerializeField] private Path _path;
        [SerializeField] private SOmovePreference _movePreference;
        

        private FireRate _fireRate;
        private Weapon _weapon;
        private PathFollowing _pathFollowing;


        private void Start()
        {
            _weapon = _shootingPreferences.CreateWeapon(_character.ShootPoint);
            _fireRate = _shootingPreferences.CreateFireRate();
            _pathFollowing = new PathFollowing(_path, this, _movePreference);

            
        }

        public void Shoot() =>
           _fireRate.Shoot(_weapon);
        
        [ContextMenu(nameof(Move))]

        public void Move() =>
            _pathFollowing.MoveToNext();

    }
   
}
