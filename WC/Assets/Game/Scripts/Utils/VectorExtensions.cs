using UnityEngine;

namespace WC
{
    public static class VectorExtensions
    {
        public static Vector2 ProjectOnPlane(Vector2 vector, Vector2 planeNormal)
        {
            float num1 = Vector2.Dot(planeNormal, planeNormal);
            if ((double) num1 < (double) Mathf.Epsilon)
                return vector;
            float num2 = Vector2.Dot(vector, planeNormal);
            return new Vector2(vector.x - planeNormal.x * num2 / num1, vector.y - planeNormal.y * num2 / num1);
        }

        public static Vector3 With(this Vector3 vector, float? x = null, float? y = null, float? z = null)
        {
            Vector3 result = new Vector3();
            result.x = x ?? vector.x;
            result.y = y ?? vector.y;
            result.z = z ?? vector.z;
            return result;
        }

        public static Vector2 With(this Vector2 vector, float? x = null, float? y = null)
        {
            Vector2 result = new Vector3();
            result.x = x ?? vector.x;
            result.y = y ?? vector.y;
            return result;
        }

        public static Vector2 ToXZ(this Vector3 vector)
        {
            return new Vector2(vector.x, vector.z);
        }

        public static Vector2 ToXY(this Vector3 vector)
        {
            return new Vector2(vector.x, vector.y);
        }

        public static Vector3 FromXZ(this Vector2 vector, float y = 0)
        {
            return new Vector3(vector.x, y, vector.y);
        }

        public static Vector3 FromXY(this Vector2 vector, float z = 0)
        {
            return new Vector3(vector.x, vector.y, z);
        }
    }
}
