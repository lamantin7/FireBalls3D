using DG.Tweening;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TweenStructures;
using UnityEngine;

namespace Tweening
{
    [CreateAssetMenu(fileName = "FatstRotationTween", menuName = "ScriptableObjects/Tweening/FatstRotationTween")]
    internal class SOFatstRotationTween:ScriptableObject, ITweenAnimation
    {
        [SerializeField] private Vector3TweenData _rotation;

        public void ApplyTo(Transform transform) =>
            ApplyTo(transform, _rotation);
        public void ApplyTo(Transform transform, Vector3TweenData rotation) => 
            transform
                .DORotate(rotation.To, rotation.Duration, RotateMode.FastBeyond360)
                .SetEase(rotation.Ease);
    }
}
