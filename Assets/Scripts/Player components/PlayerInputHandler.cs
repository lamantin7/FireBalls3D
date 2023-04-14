using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerComponents
{


    public class PlayerInputHandler : MonoBehaviour
    {
        [Header("Input")]
        [SerializeField] private InputTouchPanel _touchPanel;

        [Header("Player Components")]
        [SerializeField] private Player _player;

        private void OnEnable()
        {
            _touchPanel.Holding += Shoot;
        }
        private void OnDisable()
        {
            _touchPanel.Holding -= Shoot;
        }
        private void Shoot(Touching touch) => _player.Shoot();
    }
}
