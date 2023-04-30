using Paths;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Players
{
    public class PlayerMovement:MonoBehaviour
    {      
        [SerializeField] private SOmovePreference _movePreferences;

        [Header("Player")]
        [SerializeField] private PlayerInputHandler _inputHandler;
        [SerializeField] private Transform _player;

        public void StartMovingOn(Path path, Vector3 initialPosition)
        {
            _player.position = initialPosition;
            new PlayerPathFollowing(
                new PathFollowing(path,_player,_movePreferences),
                path,_inputHandler)
                .StartMovingAsync();
        }

    }
}
