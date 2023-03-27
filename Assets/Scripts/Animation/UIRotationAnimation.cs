using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UIRotationAnimation : MonoBehaviour
{
    [SerializeField] private float _speed;
    private void FixedUpdate()
    {
        Rotation(_speed);
    }
    private void Rotation(float speed)
    {
        
        transform.Rotate(Vector3.forward, speed);
    }
}
