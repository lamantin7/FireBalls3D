using Paths.Builders;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct PathSegment 
{
    public Transform[] WayPoints;
    public PathPlatformBuilder PlatformBuilder;
}
