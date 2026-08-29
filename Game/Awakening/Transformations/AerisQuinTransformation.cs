using System;
using SoulArena.Core;
using SoulArena.Awakening;

namespace SoulArena.Awakening.Transformations
{
    /// <summary>
    /// Unique Awakening Transformation Controller for Aeris Quin (Star Weaver).
    /// Enhances base stats, changes ability frame properties, and triggers Astral elemental aura.
    /// </summary>
    public class AerisQuinTransformation
    {
        public string FighterId { get; } = "aeris_quin";
        public bool IsTransformationActive { get; private set; } = false;
        public float TransformationTimer { get; private set; } = 0.0f;
        public const float TRANSFORMATION_MAX_TIME = 20.0f;

        public event Action<string> OnTransformationActivated;
        public event Action<string> OnTransformationDeactivated;

        public void ActivateTransformation()
        {
            IsTransformationActive = true;
            TransformationTimer = TRANSFORMATION_MAX_TIME;
            OnTransformationActivated?.Invoke("aeris_quin_awakened_form");
        }

        public void DeactivateTransformation()
        {
            IsTransformationActive = false;
            TransformationTimer = 0.0f;
            OnTransformationDeactivated?.Invoke("aeris_quin_awakened_form");
        }

        public void UpdateTransformation(float deltaTime)
        {
            if (!IsTransformationActive) return;

            TransformationTimer -= deltaTime;
            if (TransformationTimer <= 0.0f)
            {
                DeactivateTransformation();
            }
        }
    }
}
