using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Players
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
        public void Enable()=>enabled = false;
        public void Disable()=>enabled = true;
        private void Shoot(Touching touch) => _player.Shoot();
    }
}
