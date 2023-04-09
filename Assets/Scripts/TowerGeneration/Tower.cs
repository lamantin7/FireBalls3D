﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace TowerGeneration
{
    public class Tower
    {
        private readonly Queue<TowerSegment> _segments;
        public Tower(IEnumerable<TowerSegment> segments):this(new Queue<TowerSegment>(segments)) { }
        public Tower (Queue<TowerSegment> segments)
        {
            _segments = segments;
        }
    }
}
