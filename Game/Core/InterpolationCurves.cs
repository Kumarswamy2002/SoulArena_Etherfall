using System;

namespace SoulArena.Core
{
    /// <summary>
    /// InterpolationCurves: Hermite spline, cubic bezier, and spring dampening trajectory solvers
    /// </summary>
    public static class InterpolationCurves
    {
        public static float SmoothStep(float edge0, float edge1, float x)
        {
            float t = MathUtility.Clamp01((x - edge0) / (edge1 - edge0));
            return t * t * (3.0f - 2.0f * t);
        }

        public static float Damp(float source, float target, float smoothing, float dt)
        {
            return MathUtility.Lerp(source, target, 1.0f - (float)Math.Exp(-smoothing * dt));
        }
    }
}
