using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireRate : MonoBehaviour
{
    private readonly float _value;
   

    private float _lastShootTime;
    public FireRate(float value) =>
        _value = value;

    private bool _canShoot=>Time.time >= _lastShootTime+1.0f/_value;

    public void Shoot(Weapon weapon)
    {
        if(!_canShoot)
            return;

        weapon.Shoot();
        _lastShootTime = Time.time;

    }
}
