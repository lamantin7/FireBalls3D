using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Paths
{
    public class Path:MonoBehaviour
    {
        [SerializeField] private PathSegment[] _segments = Array.Empty<PathSegment>();
        public IReadOnlyList<PathSegment> Segments => _segments;
    }
}
