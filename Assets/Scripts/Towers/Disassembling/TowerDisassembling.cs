﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Towers.Generation;
using UnityEngine;
using UnityObject = UnityEngine.Object;

namespace Towers.Disassembling
{
    public class TowerDisassembling
    {
        private readonly Tower _tower;
        private readonly Transform _towerRoot;

        public TowerDisassembling(Tower tower, Transform towerRoot)
        {
            _tower = tower;
            _towerRoot = towerRoot;
        }
        public void RemoveBottom()
        {
            TowerSegment segment = _tower.RemoveBottom();
            Vector3 segmentScale = segment.transform.localScale;
            _towerRoot.position-=Vector3.up*segmentScale.y;
            UnityObject.Destroy(segment.gameObject);
        }
    }
}