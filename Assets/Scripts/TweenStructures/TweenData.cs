using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TweenStructures
{
    [System.Serializable]
    public class Vector3TweenData: TweenData<Vector3> { }
    public class TweenData<T>
    {
        public T To;
        public float Duration;
        public Ease Ease;
    }
}
