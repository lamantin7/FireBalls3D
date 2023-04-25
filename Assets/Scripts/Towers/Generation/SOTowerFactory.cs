using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;


namespace Towers.Generation
{
    [CreateAssetMenu(fileName = "TowerFactory", menuName = "ScriptableObjects/Tower/Factory")]
    public class SOTowerFactory : ScriptableObject, IAsyncTowerFactory
    {
        [SerializeField] private TowerSegment _segmentPrefab;

        [Space]
        [SerializeField][Min(0)] private int _segmentCount;
        [SerializeField][Min(0)] private float _spawnTimePerSegment;

        [Space]
        [SerializeField] private Material[] _materials=Array.Empty<Material>();

        private int SpawnTimePerSegmentMilliseconds => (int)(_spawnTimePerSegment * 1000);

        public async Task<Tower> CreateAsync(Transform tower, CancellationToken cancellationToken)
        {
            Vector3 position = tower.position;
            var segments = new Queue<TowerSegment>(_segmentCount);
            for (int i = 0; i < _segmentCount; i++)
            {
                if (cancellationToken.IsCancellationRequested)
                    break;
                TowerSegment segment = CreateSegment(tower, position, i);
                segments.Enqueue(segment);
                position=RefreshPosition(segment.transform, position);
                await Task.Delay(SpawnTimePerSegmentMilliseconds, cancellationToken);
            }
            return new Tower(segments);
        }
        private TowerSegment CreateSegment(Transform tower, Vector3 position, int numberOgImstance)
        {
            TowerSegment segment = Instantiate(_segmentPrefab, position, tower.rotation, tower);
            Material material = GetSegmentMaterialBy(numberOgImstance);
            segment.SetMaterial(material);

            return segment;
        } 
        private Vector3 RefreshPosition (Transform segment, Vector3 currentPosition)
        {
            float segmentHeight=segment.localScale.y;
            return currentPosition+Vector3.up * segmentHeight;
        }
        private Material GetSegmentMaterialBy(int numberOfInstance)
        {
            int index=numberOfInstance%_materials.Length;
            return _materials[index];
        }
    }
}
