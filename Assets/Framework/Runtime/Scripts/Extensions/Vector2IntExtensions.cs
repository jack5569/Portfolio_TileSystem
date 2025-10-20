using UnityEngine;

namespace J_Framework
{
    public static class Vector2IntExtensions
    {
        public static Vector2 ToVector2(this Vector2Int input) { return new Vector2(input.x, input.y); }
        
        public static Vector3Int ToVector3Int(this Vector2Int input) { return new Vector3Int(input.x, input.y); }
        
        public static Vector3 ToVector3(this Vector2Int input) { return new Vector3(input.x, input.y); }
    }
}