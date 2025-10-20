using UnityEngine;

namespace J_Framework
{
    public static class Vector2Extensions
    {
        public static Vector2Int ToVector2Int(this Vector2 input) { return new Vector2Int(Mathf.FloorToInt(input.x), Mathf.FloorToInt(input.y)); }
        public static Vector2Int ToFlooredVector2Int(this Vector2 input) { return new Vector2Int(Mathf.FloorToInt(input.x), Mathf.FloorToInt(input.y)); }
        public static Vector2Int ToCeiledVector2Int(this Vector2 input) { return new Vector2Int(Mathf.CeilToInt(input.x), Mathf.CeilToInt(input.y)); }

        public static Vector3Int ToVector3Int(this Vector2 input) { return new Vector3Int(Mathf.FloorToInt(input.x), Mathf.FloorToInt(input.y)); }
        public static Vector3Int ToFlooredVector3Int(this Vector2 input) { return new Vector3Int(Mathf.FloorToInt(input.x), Mathf.FloorToInt(input.y)); }
        public static Vector3Int ToCeiledVector3Int(this Vector2 input) { return new Vector3Int(Mathf.CeilToInt(input.x), Mathf.CeilToInt(input.y)); }

        public static Vector3 ToVector3(this Vector2 input) { return new Vector3(input.x, input.y); }

        public static float GetScalarProjection(Vector2 vector, Vector2 onto)
        {
            float dotProduct = Vector2.Dot(vector, onto);
            return dotProduct / onto.magnitude;
        }

        public static float GetScalarProjectionOnNormal(Vector2 vector, Vector2 planeNormal)
        {
            Vector2 dir1 = Quaternion.Euler(0.0f, 0.0f, 90.0f) * planeNormal;
            Vector2 dir2 = Quaternion.Euler(0.0f, 0.0f, -90.0f) * planeNormal;

            float angleDir1 = Vector2.Angle(vector, dir1);
            float angleDir2 = Vector2.Angle(vector, dir2);

            if (angleDir1 == angleDir2)
                return 0.0f;
            else if (angleDir1 > angleDir2)
                return GetScalarProjection(vector, dir1);
            else
                return GetScalarProjection(vector, dir2);
        }

        public static Vector2 Project(Vector2 vector, Vector2 onto)
        {
            float dotProduct = Vector2.Dot(vector, onto);
            float sqrMagnitudeOnto = onto.sqrMagnitude;
            float x = dotProduct * onto.x / sqrMagnitudeOnto;
            float y = dotProduct * onto.y / sqrMagnitudeOnto;
            return new Vector2(x, y);
        }

        public static Vector2 ProjectOnPlane(Vector2 vector, Vector2 planeNormal)
        {
            Vector2 dir1 = Quaternion.Euler(0.0f, 0.0f, 90.0f) * planeNormal;
            Vector2 dir2 = Quaternion.Euler(0.0f, 0.0f, -90.0f) * planeNormal;

            float angleWithDir1 = Vector2.Angle(vector, dir1);
            float angleWithDir2 = Vector2.Angle(vector, dir2);

            if (angleWithDir1 == angleWithDir2)
                return Vector2.zero;
            else if (angleWithDir1 > angleWithDir2)
                return Project(vector, dir1);
            else
                return Project(vector, dir2);
        }
    }
}
