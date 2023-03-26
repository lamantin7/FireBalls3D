using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace StateMachine
{
    [RequireComponent(typeof(Image))]
    [RequireComponent(typeof(AudioSource))]
    public class IconChangeButtonState : MonoState
    {
        [SerializeField] private Sprite _icon;
        [SerializeField] private AudioClip _audioClip;
        private Image _image;
        private AudioSource _audioSource;

        private void Start()
        {
            _image = GetComponent<Image>();
            _audioSource = GetComponent<AudioSource>();
            _audioSource.mute = true;
        }
        public override void Enter()
        {
            _image.sprite = _icon;
            _audioSource.PlayOneShot(_audioClip);
            _audioSource.mute=false;
            
        }

        
    }
    
}