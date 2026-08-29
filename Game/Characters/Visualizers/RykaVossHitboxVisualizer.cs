using System;
using SoulArena.Core;
using SoulArena.Combat;

namespace SoulArena.Characters.Visualizers
{
    /// <summary>
    /// Debug Gizmo & Hitbox Extent Renderer for Ryka Voss (Ember Wolf).
    /// </summary>
    public class RykaVossHitboxVisualizer
    {
        public bool ShowHitboxes { get; set; } = true;
        public bool ShowHurtboxes { get; set; } = true;

        public void RenderDebugGizmos(FighterBase fighter)
        {
            if (fighter == null) return;
        }
    }
}
