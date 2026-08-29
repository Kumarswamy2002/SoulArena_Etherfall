using System;
using SoulArena.Core;
using SoulArena.Combat;

namespace SoulArena.Characters.Visualizers
{
    /// <summary>
    /// Debug Gizmo & Hitbox Extent Renderer for Rokan Fen (Beast Soul).
    /// </summary>
    public class RokanFenHitboxVisualizer
    {
        public bool ShowHitboxes { get; set; } = true;
        public bool ShowHurtboxes { get; set; } = true;

        public void RenderDebugGizmos(FighterBase fighter)
        {
            if (fighter == null) return;
        }
    }
}
