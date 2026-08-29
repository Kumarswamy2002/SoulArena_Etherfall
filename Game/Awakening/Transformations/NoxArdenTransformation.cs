using System;
using SoulArena.Core;
using SoulArena.Awakening;

namespace SoulArena.Awakening.Transformations
{
    /// <summary>
    /// Unique Awakening Transformation Controller for Nox Arden (Riftborn).
    /// Enhances base stats, changes ability frame properties, and triggers Rift elemental aura.
    /// </summary>
    public class NoxArdenTransformation
    {
        public string FighterId { get; } = "nox_arden";
        public bool IsTransformationActive { get; private set; } = false;
        public float TransformationTimer { get; private set; } = 0.0f;
        public const float TRANSFORMATION_MAX_TIME = 20.0f;

        public event Action<string> OnTransformationActivated;
        public event Action<string> OnTransformationDeactivated;

        public void ActivateTransformation()
        {
            IsTransformationActive = true;
            TransformationTimer = TRANSFORMATION_MAX_TIME;
            OnTransformationActivated?.Invoke("nox_arden_awakened_form");
        }

        public void DeactivateTransformation()
        {
            IsTransformationActive = false;
            TransformationTimer = 0.0f;
            OnTransformationDeactivated?.Invoke("nox_arden_awakened_form");
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
