using System;
using UnityEngine;
namespace My2DPlatformer
{
    [Serializable]
    public struct AIConfig
    {
        public float Speed;
        public float MinSqrDistanceToTarget;
        public Transform[] Waypoints;
    }
}