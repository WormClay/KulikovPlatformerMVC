using System;
using UnityEngine;
namespace PlatformerMVC
{
    static public class Utils
    {
        public static Vector3 Change(this Vector3 org, object x = null, object y = null, object z = null)
        {
            return new Vector3(x == null ? org.x : (float)x, y == null ? org.y : (float)y, z == null ? org.z : (float)z);
        }
        public static Vector2 Change(this Vector2 org, object x = null, object y = null)
        {
            return new Vector2(x == null ? org.x : (float)x, y == null ? org.y : (float)y);
        }
    }
    public enum DangerType
    {
        fire,
        laser,
        none
    }
    [Serializable]
    public struct AIConfig
    {
        public float speed;
        public float minDistanceToTarget;
        public Transform[] waypoints;
        public Transform playerTransform;
        public float maxDistanceToPlayer;
    }
}