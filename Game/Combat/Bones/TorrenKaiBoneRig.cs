using System;
using System.Collections.Generic;
using SoulArena.Core;

namespace SoulArena.Combat.Bones
{
    /// <summary>
    /// Skeletal Bone Capsule Attachment & Hurtbox Rigging for Torren Kai (Wind Dancer).
    /// </summary>
    public class TorrenKaiBoneRig
    {
        public struct BoneCapsule
        {
            public string BoneName;
            public Vector3D LocalOffset;
            public float Radius;
            public float Height;
        }

        private readonly List<BoneCapsule> _bones = new List<BoneCapsule>();

        public TorrenKaiBoneRig()
        {
            _bones.Add(new BoneCapsule { BoneName = "Head", LocalOffset = new Vector3D(0f, 1.65f, 0f), Radius = 0.22f, Height = 0.25f });
            _bones.Add(new BoneCapsule { BoneName = "Chest", LocalOffset = new Vector3D(0f, 1.25f, 0f), Radius = 0.35f, Height = 0.45f });
            _bones.Add(new BoneCapsule { BoneName = "Pelvis", LocalOffset = new Vector3D(0f, 0.85f, 0f), Radius = 0.30f, Height = 0.35f });
            _bones.Add(new BoneCapsule { BoneName = "LeftLeg", LocalOffset = new Vector3D(-0.2f, 0.45f, 0f), Radius = 0.18f, Height = 0.55f });
            _bones.Add(new BoneCapsule { BoneName = "RightLeg", LocalOffset = new Vector3D(0.2f, 0.45f, 0f), Radius = 0.18f, Height = 0.55f });
        }

        public IReadOnlyList<BoneCapsule> GetBoneCapsules() => _bones;
    }
}
