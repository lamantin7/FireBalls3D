using ReactiveProperties;
using Shooting.Pool;
using Structures.ReactiveProperties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Towers.Disassembling;
using Towers.Effects;
using Towers.Generation;
using Tweening;
using UI.Tower;
using UnityEngine;

namespace Paths.Builders
{
   public class PathTowerBuilder:MonoBehaviour
    {
        [SerializeField] private Transform _towerRoot;

        [Header("Effects")]
        [SerializeField] private SOFatstRotationTween _spawnAnimation;

        [Header("Linked Components")]
        [SerializeField] private RestoreProjectilePoolTrigger _projectileHitTrigger;
        [SerializeField] private TowerSegmentsLeftText _segmentsLeftText;
        [SerializeField] private TowerAudio _audio;

        private Action _unsubscribe;
        private SOTowerStructure _structure;

        public void Initialize(SOTowerStructure structure)
        {
            _structure= structure;
        }
        public async Task<TowerDisassembling> BuildAsync(ProjectilePool pool)
        {
            _spawnAnimation.ApplyTo(_towerRoot);
            _projectileHitTrigger.Initialize(pool);
            TowerGenerator generator = new TowerGenerator(_structure);
            generator.SegmentCreated += _segmentsLeftText.UpdateTextValue;
            Tower tower = await generator.CreateAsync(_towerRoot);
            TowerDisassembling disassembling = new TowerDisassembling(tower, _towerRoot);

            SubscribeComponents(generator, tower, disassembling);
            return disassembling;
        }

        private void OnDisable() =>
            _unsubscribe?.Invoke();
        private void SubscribeComponents(TowerGenerator generator, Tower tower, TowerDisassembling disassembling)
        {
            _projectileHitTrigger.ProjectileReturned += disassembling.TryRemoveBottom;
            IReadonlyReactiveProperty<int> segmentCount = tower.SegmentCount;

            segmentCount.Subscribe(_segmentsLeftText.UpdateTextValue);
            segmentCount.Subscribe(_audio.PlaySound);
            _unsubscribe = () =>
            {
                generator.Dispose();
                generator.SegmentCreated -= _segmentsLeftText.UpdateTextValue;
                _projectileHitTrigger.ProjectileReturned -= disassembling.TryRemoveBottom;
                segmentCount.Unsubscribe(_segmentsLeftText.UpdateTextValue);
                segmentCount.Unsubscribe(_audio.PlaySound);
            };
        }

        
    }
}
