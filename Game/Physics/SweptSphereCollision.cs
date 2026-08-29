using System;
using SoulArena.Core;

namespace SoulArena.Physics
{
    public struct SweepHitResult
    {
        public bool Hit;
        public float Distance;
        public Vector3D Point;
        public Vector3D Normal;
        public float Fraction;
    }

    /// <summary>
    /// Continuous Collision Detection (CCD) Ray & Swept Sphere testing engine.
    /// Prevents high-velocity projectiles and dash-cancels from passing through opponent hitboxes.
    /// </summary>
    public static class SweptSphereCollision
    {
        public static bool CastRay(Vector3D origin, Vector3D direction, float maxDistance, Vector3D sphereCenter, float sphereRadius, out SweepHitResult result)
        {
            result = default;
            Vector3D m = origin - sphereCenter;
            float b = Vector3D.Dot(m, direction);
            float c = Vector3D.Dot(m, m) - (sphereRadius * sphereRadius);

            if (c > 0.0f && b > 0.0f) return false;

            float discr = b * b - c;
            if (discr < 0.0f) return false;

            float t = -b - (float)Math.Sqrt(discr);
            if (t < 0.0f) t = 0.0f;

            if (t > maxDistance) return false;

            result.Hit = true;
            result.Distance = t;
            result.Fraction = t / maxDistance;
            result.Point = origin + direction * t;
            result.Normal = (result.Point - sphereCenter).Normalized;

            return true;
        }

        public static bool SweepSphere(Vector3D startPos, Vector3D endPos, float sphereRadius, Vector3D obstacleCenter, float obstacleRadius, out SweepHitResult hit)
        {
            hit = default;
            Vector3D dir = endPos - startPos;
            float dist = dir.Magnitude;
            if (dist < 0.0001f) return false;

            Vector3D normalizedDir = dir / dist;
            float combinedRadius = sphereRadius + obstacleRadius;

            return CastRay(startPos, normalizedDir, dist, obstacleCenter, combinedRadius, out hit);
        }
    }
}
