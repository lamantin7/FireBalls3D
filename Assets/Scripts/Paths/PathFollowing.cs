using DG.Tweening;
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
        private readonly Transform _follower;
        private readonly SOmovePreference _preferences;

        private int _pathSegmentIndex;

        public PathFollowing(Path path, Transform follower, SOmovePreference preferences)
        {
            _path = path;
            _follower = follower;
            _preferences = preferences;
           
        }
        public async Task MoveToNextAsync()
        {
            if (_pathSegmentIndex >= _path.Segments.Count)
                return;

            PathSegment segment = _path.Segments[_pathSegmentIndex];
            Transform[] waypoints = segment.WayPoints;

            await MoveBetweenAsync(_follower, waypoints);
                        
        }

        private async Task MoveBetweenAsync(Transform follower, IReadOnlyList<Transform> waypoints)
        {
            int index = 1;
            

            while(index < waypoints.Count) 
            {
                Vector3 position = waypoints[index].position;

                Task LookAt = follower
                    .DOLookAt(position, _preferences.RotateDuration)
                    .AsyncWaitForCompletion();
                    
                Task move = follower
                    .DOMove(position, _preferences.RotateDuration)
                    .AsyncWaitForCompletion();
                await Task.WhenAll(LookAt, move);

                index++;
            }
            _pathSegmentIndex++;
        }
    }
}
