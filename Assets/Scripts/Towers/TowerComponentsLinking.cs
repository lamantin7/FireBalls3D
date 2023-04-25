using Shooting.Pool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Towers.Disassembling;
using Towers.Generation;
using UI.Tower;
using UnityEngine;

namespace Towers
{
   public class TowerComponentsLinking:MonoBehaviour
    {
        [SerializeField] private Transform _towerRoot;
        [SerializeField] private TowerGenerator _generator;
        [SerializeField] private RestoreProjectilePoolTrigger _projectileHitTrigger;
        [SerializeField] private TowerSegmentsLeftText _segmentsLeftText;

        private TowerDisassembling _disassembling;
        private Tower _tower;
        [ContextMenu(nameof(Prepare))]
        public async Task Prepare()
        {
            _tower=await _generator.Generate();
            _disassembling= new TowerDisassembling(_tower, _towerRoot);
            _projectileHitTrigger.ProjectileReturned += _disassembling.RemoveBottom;
        }
        private void OnDisable()
        {
            if (_disassembling!=null)                   
                _projectileHitTrigger.ProjectileReturned -= _disassembling.RemoveBottom;
        }
    }
}
