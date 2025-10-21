using UnityEngine;

public static class Vector2IntExtensions
{
    public static Vector3Int ToVector3Int(this Vector2Int value) { return new Vector3Int(value.x, value.y, 0); }
}
