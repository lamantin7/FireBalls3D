using System;
using System.Collections.Generic;
using UnityObject = UnityEngine.Object;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;


namespace Towers.Generation
{
    [CreateAssetMenu(fileName = "TowerStructure", menuName = "ScriptableObjects/Tower/Structure")]
    public class SOTowerStructure : ScriptableObject
    { 
        [SerializeField] private TowerSegment _segmentPrefab;

        [Space]
        [SerializeField][Min(0)] private int _segmentCount;
        [SerializeField][Min(0)] private float _spawnTimePerSegment;

        [Space]
        [SerializeField] private Material[] _materials=Array.Empty<Material>();
               
        public int SpawnTimePerSegmentMilliseconds => (int)(_spawnTimePerSegment * 1000);

        public TowerSegment SegmentPrefab => _segmentPrefab;

        public int SegmentCount => _segmentCount;

        public Material GetSegmentMaterialBy(int numberOfInstance)
        {
            int index = numberOfInstance % _materials.Length;
            return _materials[index];
        }
        public TowerSegment CreateSegment(Transform tower, Vector3 position, int numberOgImstance)
        {
            TowerSegment segment = Instantiate(_segmentPrefab, position, tower.rotation, tower);
            Material material = GetSegmentMaterialBy(numberOgImstance);
            segment.SetMaterial(material);

            return segment;
        }





       
        private Vector3 RefreshPosition(Transform segment, Vector3 currentPosition)
        {
            float segmentHeight = segment.localScale.y;
            return currentPosition + Vector3.up * segmentHeight;
        }

    }
}
