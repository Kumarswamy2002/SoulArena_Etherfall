using System;
using SoulArena.Core;

namespace SoulArena.AI.Curves
{
    /// <summary>
    /// Non-linear Utility Spacing Curves for Mira Tide (Tideblade).
    /// </summary>
    public class MiraTideSpacingCurve
    {
        public float SweetSpotDistance { get; set; } = 2.7f;
        public float CurveTension { get; set; } = 1.8f;

        public float EvaluatePositioningScore(float currentDistance)
        {
            float delta = Math.Abs(currentDistance - SweetSpotDistance);
            return (float)Math.Exp(-delta * CurveTension);
        }
    }
}
