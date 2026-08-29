using System;
using SoulArena.Core;
using SoulArena.Characters;
using SoulArena.Networking;

namespace SoulArena.Characters.Networking
{
    /// <summary>
    /// Binary Delta-Compression Serialization Adapter for Vexa Noir (Void Walker).
    /// </summary>
    public static class VexaNoirNetworkAdapter
    {
        public static byte[] SerializeState(FighterBase fighter)
        {
            if (fighter == null) return new byte[0];

            byte[] buffer = new byte[32];
            BitConverter.GetBytes(fighter.Position.X).CopyTo(buffer, 0);
            BitConverter.GetBytes(fighter.Position.Y).CopyTo(buffer, 4);
            BitConverter.GetBytes(fighter.CurrentHealth).CopyTo(buffer, 8);
            BitConverter.GetBytes(fighter.Ether.CurrentEther).CopyTo(buffer, 12);
            BitConverter.GetBytes(fighter.Defense.CurrentGuard).CopyTo(buffer, 16);
            BitConverter.GetBytes(fighter.Resonance.CurrentResonance).CopyTo(buffer, 20);
            buffer[24] = (byte)(fighter.FacingRight ? 1 : 0);
            buffer[25] = (byte)(fighter.Awakening.IsAwakened ? 1 : 0);

            return buffer;
        }

        public static void DeserializeState(byte[] buffer, FighterBase fighter)
        {
            if (buffer == null || buffer.Length < 26 || fighter == null) return;

            float x = BitConverter.ToSingle(buffer, 0);
            float y = BitConverter.ToSingle(buffer, 4);
            fighter.Position = new Vector3D(x, y, fighter.Position.Z);
            fighter.FacingRight = buffer[24] == 1;
        }
    }
}
