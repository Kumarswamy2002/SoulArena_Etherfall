using System;

namespace SoulArena.Core
{
    public struct Vector3D
    {
        public float X;
        public float Y;
        public float Z;

        public Vector3D(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public static Vector3D Zero => new Vector3D(0, 0, 0);
        public static Vector3D Up => new Vector3D(0, 1, 0);
        public static Vector3D Forward => new Vector3D(0, 0, 1);
        public static Vector3D Right => new Vector3D(1, 0, 0);

        public float SqrMagnitude => X * X + Y * Y + Z * Z;
        public float Magnitude => (float)Math.Sqrt(SqrMagnitude);

        public Vector3D Normalized
        {
            get
            {
                float mag = Magnitude;
                if (mag > 0.00001f)
                    return new Vector3D(X / mag, Y / mag, Z / mag);
                return Zero;
            }
        }

        public static Vector3D operator +(Vector3D a, Vector3D b) => new Vector3D(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        public static Vector3D operator -(Vector3D a, Vector3D b) => new Vector3D(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
        public static Vector3D operator *(Vector3D a, float scalar) => new Vector3D(a.X * scalar, a.Y * scalar, a.Z * scalar);
        public static Vector3D operator *(float scalar, Vector3D a) => new Vector3D(a.X * scalar, a.Y * scalar, a.Z * scalar);
        public static Vector3D operator /(Vector3D a, float scalar) => new Vector3D(a.X / scalar, a.Y / scalar, a.Z / scalar);

        public static float Dot(Vector3D a, Vector3D b) => a.X * b.X + a.Y * b.Y + a.Z * b.Z;
        public static float Distance(Vector3D a, Vector3D b) => (a - b).Magnitude;

        public static Vector3D Lerp(Vector3D a, Vector3D b, float t)
        {
            t = MathUtility.Clamp01(t);
            return new Vector3D(a.X + (b.X - a.X) * t, a.Y + (b.Y - a.Y) * t, a.Z + (b.Z - a.Z) * t);
        }
    }

    public static class MathUtility
    {
        public const float PI = 3.1415926535897931f;
        public const float DEG_TO_RAD = PI / 180.0f;
        public const float RAD_TO_DEG = 180.0f / PI;

        public static float Clamp(float value, float min, float max)
        {
            if (value < min) return min;
            if (value > max) return max;
            return value;
        }

        public static float Clamp01(float value)
        {
            if (value < 0.0f) return 0.0f;
            if (value > 1.0f) return 1.0f;
            return value;
        }

        public static float Lerp(float a, float b, float t)
        {
            return a + (b - a) * Clamp01(t);
        }

        public static bool CheckSphereIntersection(Vector3D centerA, float radiusA, Vector3D centerB, float radiusB)
        {
            float distSqr = (centerA - centerB).SqrMagnitude;
            float radiusSum = radiusA + radiusB;
            return distSqr <= (radiusSum * radiusSum);
        }

        public static bool CheckCapsuleSphereIntersection(Vector3D capsuleBottom, Vector3D capsuleTop, float capsuleRadius, Vector3D sphereCenter, float sphereRadius)
        {
            Vector3D capsuleSegment = capsuleTop - capsuleBottom;
            float segmentLengthSqr = capsuleSegment.SqrMagnitude;
            if (segmentLengthSqr < 0.0001f)
            {
                return CheckSphereIntersection(capsuleBottom, capsuleRadius, sphereCenter, sphereRadius);
            }

            float t = Dot(sphereCenter - capsuleBottom, capsuleSegment) / segmentLengthSqr;
            t = Clamp01(t);
            Vector3D closestPoint = capsuleBottom + capsuleSegment * t;

            return CheckSphereIntersection(closestPoint, capsuleRadius, sphereCenter, sphereRadius);
        }

        private static float Dot(Vector3D a, Vector3D b) => a.X * b.X + a.Y * b.Y + a.Z * b.Z;
    }
}
