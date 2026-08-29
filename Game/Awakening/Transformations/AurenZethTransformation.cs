using System;
using SoulArena.Core;
using SoulArena.Awakening;

namespace SoulArena.Awakening.Transformations
{
    /// <summary>
    /// Unique Awakening Transformation Controller for Auren Zeth (First Soul).
    /// Enhances base stats, changes ability frame properties, and triggers PrimeEther elemental aura.
    /// </summary>
    public class AurenZethTransformation
    {
        public string FighterId { get; } = "auren_zeth";
        public bool IsTransformationActive { get; private set; } = false;
        public float TransformationTimer { get; private set; } = 0.0f;
        public const float TRANSFORMATION_MAX_TIME = 20.0f;

        public event Action<string> OnTransformationActivated;
        public event Action<string> OnTransformationDeactivated;

        public void ActivateTransformation()
        {
            IsTransformationActive = true;
            TransformationTimer = TRANSFORMATION_MAX_TIME;
            OnTransformationActivated?.Invoke("auren_zeth_awakened_form");
        }

        public void DeactivateTransformation()
        {
            IsTransformationActive = false;
            TransformationTimer = 0.0f;
            OnTransformationDeactivated?.Invoke("auren_zeth_awakened_form");
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
