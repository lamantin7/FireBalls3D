using Coroutines;
using Structures;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace MyPhysics
{
    [System.Serializable]
    public class DirectionalBouncePreferences
    {
        public float Duration;
        public float Height;
        public AnimationCurve Trajectory;

        public DirectionalBouncePreferences(float duration, float height, AnimationCurve trajectory)
        {
            Duration = duration;
            Height = height;
            Trajectory = trajectory;
        }
    }
   public class DirectionalBounce
    {
        private readonly Transform _bouncer;
        private readonly CoroutineExecutor _coroutineExecutor;
        private readonly DirectionalBouncePreferences _preferences;

        public DirectionalBounce(Transform bouncer, CoroutineExecutor coroutineExecutor, DirectionalBouncePreferences preferences)
        {
            _bouncer = bouncer;
            _coroutineExecutor = coroutineExecutor;
            _preferences = preferences;
        }
        public void BounceTo(Vector3 target, Vector3 startPosition)=>
            _coroutineExecutor.Start(InterpolatePositionTo(target, startPosition));
        private IEnumerator InterpolatePositionTo(Vector3 target, Vector3 startPosition)
        {
            var timer = new UnityTimer();
            timer.Start(_preferences.Duration);
            while (timer.IsTimeUp==false) 
            {
                float t = timer.ElapsedTimePercemt;
                Vector3 newPosition= CalculatePosition(target, startPosition,t);
                _bouncer.transform.position = newPosition;
                yield return null;
                                
            }

        }
        private Vector3 CalculatePosition(Vector3 target,Vector3 startPosition, float t)=>
            Vector3.Lerp(startPosition, target- new Vector3(0,2,0), t)
            +Vector3.up* (_preferences.Trajectory.Evaluate(t)*_preferences.Height);
    }
}
