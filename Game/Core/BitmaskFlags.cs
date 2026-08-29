using System;

namespace SoulArena.Core
{
    /// <summary>
    /// BitmaskFlags: High performance 64-bit combat state bitfield encoders and decoders
    /// </summary>
    public static class BitmaskFlags
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
