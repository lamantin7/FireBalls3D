using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace TweenStructures
{
    public class Vector3RangedTweenData : RangedTweenData<Vector3> { }
    public class Vector2RangedTweenData : RangedTweenData<Vector2> { }

    public class RangedTweenData<T>:TweenData<T>
    {
        public T From;
    }
}
