using UnityEngine;

namespace J_Framework
{
    public static class Vector3Extensions
    {
        public static Vector3Int ToVector3Int(this Vector3 input) { return new Vector3Int(Mathf.FloorToInt(input.x), Mathf.FloorToInt(input.y), Mathf.FloorToInt(input.z)); }
        public static Vector3Int ToFlooredVector3Int(this Vector3 input) { return new Vector3Int(Mathf.FloorToInt(input.x), Mathf.FloorToInt(input.y), Mathf.FloorToInt(input.z)); }
        public static Vector3Int ToCeiledVector3Int(this Vector3 input) { return new Vector3Int(Mathf.CeilToInt(input.x), Mathf.CeilToInt(input.y), Mathf.CeilToInt(input.z)); }
    }
}