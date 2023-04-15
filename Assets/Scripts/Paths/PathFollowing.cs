﻿using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Paths
{
    public class PathFollowing
    {
        private readonly Path _path;
        private readonly MonoBehaviour _follower;
        private readonly SOmovePreference _preferences;

        private int _pathSegmentIndex;

        public PathFollowing(Path path, MonoBehaviour follower, SOmovePreference preferences)
        {
            _path = path;
            _follower = follower;
            _preferences = preferences;
           
        }
        public void MoveToNext()
        {
            if (_pathSegmentIndex >= _path.Segments.Count)
                return;

            PathSegment segment = _path.Segments[_pathSegmentIndex];
            Transform[] waypoints = segment.WayPoints;

            _follower.StartCoroutine(MoveBetween(waypoints));
        }

        private IEnumerator MoveBetween(IReadOnlyList<Transform> waypoints)
        {
            int index = 1;
            Transform followerTransform= _follower.transform;

            while(index < waypoints.Count) 
            {
                Vector3 position = waypoints[index].position;

                followerTransform
                    .DOLookAt(position,_preferences.RotateDuration)
                    .OnComplete(()=>followerTransform
                    .DOMove(position,_preferences.DurationPerWaypoint));
                yield return new WaitForSeconds(_preferences.TotalDuration);
                index++;
            }
            _pathSegmentIndex++;
        }
    }
}
