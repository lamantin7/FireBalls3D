using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireRate : MonoBehaviour
{
    private readonly float _value;
    private readonly Weapon _weapon;

    private float _lastShootTime;
    public FireRate(float value,Weapon weapon)
    {
        _weapon = weapon;
        _value = value;
    }

    private bool _canShoot=>Time.time >= _lastShootTime+1.0f/_value;

    public void Shoot()
    {
        if(!_canShoot)
            return;

        _weapon.Shoot();
        _lastShootTime = Time.time;

    }
}
