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
    public class TowerGenerator : IAsyncTowerGenerator, ITowerSegmentCreationCallback, IDisposable
    {
        
        private readonly SOTowerStructure _structure;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();

        public TowerGenerator(SOTowerStructure structure)
        {
            _structure = structure;
        }

        public event Action<int> SegmentCreated;

        public async Task<Tower> CreateAsync(Transform tower) => 
            await CreateAsync(tower, _cancellationTokenSource.Token);
        public void Dispose() => 
            _cancellationTokenSource.Cancel();
        public async Task<Tower> CreateAsync(Transform tower, CancellationToken cancellationToken)
        {
            Vector3 position = tower.position;
            int segmentCount = _structure.SegmentCount;
            var segments = new Queue<TowerSegment>(segmentCount);
            for (int i = 0; i < segmentCount; i++)
            {
                if (cancellationToken.IsCancellationRequested)
                    break;
                TowerSegment segment = _structure.CreateSegment(tower, position, i);
                segments.Enqueue(segment);
                position = RefreshPosition(segment.transform, position);
                SegmentCreated?.Invoke(i + 1);
                await Task.Delay(_structure.SpawnTimePerSegmentMilliseconds, cancellationToken);
            }
            return new Tower(segments);
        }
        private Vector3 RefreshPosition(Transform segment, Vector3 currentPosition)
        {
            float segmentHeight = segment.localScale.y;
            return currentPosition + Vector3.up * segmentHeight;
        }



    }
}