using System.Collections;
using System.Collections.Generic;
using Towers.Generation;
using System;
using UnityEngine;
using UnityObject = UnityEngine.Object;
using System.Threading;
using TweenStructures;
using DG.Tweening;
using System.Threading.Tasks;

namespace Towers.Generation
{
    public class TowerGenerator : MonoBehaviour
    {
        [SerializeField] private UnityObject _towerFactory;
        [SerializeField] private Transform _towerRoot;
        [SerializeField] private Vector3TweenData _rotationData;

        private IAsyncTowerFactory TowerFactory => (IAsyncTowerFactory)_towerFactory;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();

        private void OnValidate()
        {
            if (_towerFactory != null && _towerFactory is IAsyncTowerFactory == false)
            {
                _towerFactory = null;
                throw new InvalidOperationException($"Tower factory should be derived from {nameof(IAsyncTowerFactory)}");
            }
        }
        private void OnDisable()
        {
            _cancellationTokenSource.Cancel();
        }
        [ContextMenu(nameof(Generate))]
        public async Task<Tower> Generate()
        {
            ApplyRotation(_rotationData);
            return await TowerFactory.CreateAsync(_towerRoot, _cancellationTokenSource.Token);
        }
        private void ApplyRotation(Vector3TweenData rotationData)
        {
            _towerRoot
                .DORotate(rotationData.To, rotationData.Duration, RotateMode.FastBeyond360)
                .SetEase(rotationData.Ease);
        }
    }
}