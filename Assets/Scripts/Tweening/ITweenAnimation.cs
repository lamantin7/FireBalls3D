using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tweening
{
    public interface ITweenAnimation
    {
        void ApplyTo(Transform transform);
    }
}