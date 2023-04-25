using Paths;
using Shooting;
using Shooting.Pool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerComponents
{


    public class Player : MonoBehaviour
    {
        [SerializeField] private Character _character;
        [SerializeField] private SOshootingPreferences _shootingPreferences;
        [SerializeField] private ProjectilePool _projectilePool;

        [SerializeField] private Path _path;
        [SerializeField] private SOmovePreference _movePreference;
        

        private FireRate _fireRate;
        private Weapon _weapon;
        private PathFollowing _pathFollowing;


        private void Start()
        {
            _projectilePool.Initialize(_shootingPreferences.ProjectileFactory);
            _projectilePool.Prewarm(20);

            _weapon = new Weapon (_character.ShootPoint,_projectilePool,_shootingPreferences.ProjectileSpeed);
            _fireRate = new FireRate(_shootingPreferences.FireRate);
            _pathFollowing = new PathFollowing(_path, this, _movePreference);;

            
        }

        public void Shoot() =>
           _fireRate.Shoot(_weapon);
        
        [ContextMenu(nameof(Move))]

        public void Move() =>
            _pathFollowing.MoveToNext();

    }
   
}
