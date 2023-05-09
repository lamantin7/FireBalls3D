using Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Levels
{
    public class LevelLostListener:MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private AssetReferenceGameObject _loseScreen;

        private void OnEnable() =>
            _player.Died += OnPlayerDied;
        private void OnDisable() => 
            _player.Died -= OnPlayerDied;
        private void OnPlayerDied() =>
            _loseScreen.InstantiateAsync();

    }
}
