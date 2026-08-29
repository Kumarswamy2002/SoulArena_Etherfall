using System;
using SoulArena.Core;
using SoulArena.Characters;

namespace SoulArena.Arenas.Bounds
{
    /// <summary>
    /// Stage Geometry, Wall Collision, and Camera Clamping Matrix for SunkenCitadel.
    /// Stage Dimensions: 40.0m x 20.0m x 20.0m
    /// </summary>
    public class SunkenCitadelBoundsController
    {
        public Vector3D ArenaExtents { get; } = new Vector3D(40.0f, 20.0f, 20.0f);
        public float LeftWallX => -ArenaExtents.X * 0.5f;
        public float RightWallX => ArenaExtents.X * 0.5f;

        public event Action<FighterBase, string> OnFighterHitWall;

        public void ConstrainFighterToArena(FighterBase fighter)
        {
            if (fighter == null) return;

            float posX = fighter.Position.X;
            if (posX <= LeftWallX)
            {
                fighter.Position = new Vector3D(LeftWallX, fighter.Position.Y, fighter.Position.Z);
                fighter.Velocity = new Vector3D(0.0f, fighter.Velocity.Y, fighter.Velocity.Z);
                OnFighterHitWall?.Invoke(fighter, "WestWall");
            }
            else if (posX >= RightWallX)
            {
                fighter.Position = new Vector3D(RightWallX, fighter.Position.Y, fighter.Position.Z);
                fighter.Velocity = new Vector3D(0.0f, fighter.Velocity.Y, fighter.Velocity.Z);
                OnFighterHitWall?.Invoke(fighter, "EastWall");
            }
        }
    }
}
