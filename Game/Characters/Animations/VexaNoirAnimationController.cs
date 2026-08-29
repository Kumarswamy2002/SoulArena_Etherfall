using System;
using System.Collections.Generic;
using SoulArena.Core;
using SoulArena.Combat;

namespace SoulArena.Characters.Animations
{
    /// <summary>
    /// Animation Frame Dispatcher & State Evaluator for Vexa Noir (Void Walker).
    /// Synchronizes Unity Mecanim animation clips with discrete 60 FPS combat frame data.
    /// </summary>
    public class VexaNoirAnimationController
    {
        public int FighterId { get; private set; }
        public string CurrentClipName { get; private set; } = "VexaNoir_Idle";
        public int CurrentNormalizedFrame { get; private set; } = 0;
        public float PlaybackSpeedMultiplier { get; set; } = 1.0f;
        public bool IsTransitioning { get; private set; } = false;

        private readonly Dictionary<string, int> _clipTotalFrames = new Dictionary<string, int>();
        private readonly Dictionary<string, List<Action<int>>> _frameEvents = new Dictionary<string, List<Action<int>>>();

        public event Action<string> OnAnimationStarted;
        public event Action<string> OnAnimationCompleted;
        public event Action<string, int> OnHitboxWindowActivated;
        public event Action<string, int> OnHitboxWindowDeactivated;

        public VexaNoirAnimationController(int fighterId)
        {
            FighterId = fighterId;
            InitializeClipDatabase();
            RegisterFrameEvents();
        }

        private void InitializeClipDatabase()
        {
            _clipTotalFrames["VexaNoir_Idle"] = 60;
            _clipTotalFrames["VexaNoir_MoveForward"] = 30;
            _clipTotalFrames["VexaNoir_MoveBackward"] = 30;
            _clipTotalFrames["VexaNoir_DashForward"] = 18;
            _clipTotalFrames["VexaNoir_DashBackward"] = 18;
            _clipTotalFrames["VexaNoir_JumpStart"] = 6;
            _clipTotalFrames["VexaNoir_JumpLoop"] = 30;
            _clipTotalFrames["VexaNoir_JumpLand"] = 8;
            _clipTotalFrames["VexaNoir_GuardStart"] = 4;
            _clipTotalFrames["VexaNoir_GuardHold"] = 60;
            _clipTotalFrames["VexaNoir_ParryAction"] = 24;
            _clipTotalFrames["VexaNoir_HitStunLight"] = 14;
            _clipTotalFrames["VexaNoir_HitStunHeavy"] = 28;
            _clipTotalFrames["VexaNoir_Knockdown"] = 45;
            _clipTotalFrames["VexaNoir_GetUp"] = 20;

            // Attack Clips
            _clipTotalFrames["VexaNoir_Attack_Light1"] = 14;
            _clipTotalFrames["VexaNoir_Attack_Light2"] = 16;
            _clipTotalFrames["VexaNoir_Attack_Light3"] = 20;
            _clipTotalFrames["VexaNoir_Attack_Heavy"] = 34;
            _clipTotalFrames["VexaNoir_Attack_Launcher"] = 27;
            _clipTotalFrames["VexaNoir_Air_Strike"] = 18;
            _clipTotalFrames["VexaNoir_Ability1"] = 26;
            _clipTotalFrames["VexaNoir_Ability2"] = 32;
            _clipTotalFrames["VexaNoir_Ability3"] = 28;
            _clipTotalFrames["VexaNoir_Ultimate"] = 72;
        }

        private void RegisterFrameEvents()
        {
            // Bind hitbox active windows to exact animation frames
            RegisterClipEvent("VexaNoir_Attack_Light1", (frame) =>
            {
                if (frame == 4) OnHitboxWindowActivated?.Invoke("VexaNoir_Attack_Light1", frame);
                if (frame == 7) OnHitboxWindowDeactivated?.Invoke("VexaNoir_Attack_Light1", frame);
            });

            RegisterClipEvent("VexaNoir_Attack_Light2", (frame) =>
            {
                if (frame == 5) OnHitboxWindowActivated?.Invoke("VexaNoir_Attack_Light2", frame);
                if (frame == 8) OnHitboxWindowDeactivated?.Invoke("VexaNoir_Attack_Light2", frame);
            });

            RegisterClipEvent("VexaNoir_Attack_Light3", (frame) =>
            {
                if (frame == 6) OnHitboxWindowActivated?.Invoke("VexaNoir_Attack_Light3", frame);
                if (frame == 10) OnHitboxWindowDeactivated?.Invoke("VexaNoir_Attack_Light3", frame);
            });

            RegisterClipEvent("VexaNoir_Attack_Heavy", (frame) =>
            {
                if (frame == 11) OnHitboxWindowActivated?.Invoke("VexaNoir_Attack_Heavy", frame);
                if (frame == 16) OnHitboxWindowDeactivated?.Invoke("VexaNoir_Attack_Heavy", frame);
            });

            RegisterClipEvent("VexaNoir_Attack_Launcher", (frame) =>
            {
                if (frame == 8) OnHitboxWindowActivated?.Invoke("VexaNoir_Attack_Launcher", frame);
                if (frame == 12) OnHitboxWindowDeactivated?.Invoke("VexaNoir_Attack_Launcher", frame);
            });

            RegisterClipEvent("VexaNoir_Ultimate", (frame) =>
            {
                if (frame == 18) OnHitboxWindowActivated?.Invoke("VexaNoir_Ultimate", frame);
                if (frame == 36) OnHitboxWindowDeactivated?.Invoke("VexaNoir_Ultimate", frame);
            });
        }

        public void RegisterClipEvent(string clipName, Action<int> callback)
        {
            if (!_frameEvents.ContainsKey(clipName))
            {
                _frameEvents[clipName] = new List<Action<int>>();
            }
            _frameEvents[clipName].Add(callback);
        }

        public void PlayClip(string clipName, float speed = 1.0f)
        {
            if (!_clipTotalFrames.ContainsKey(clipName)) return;
            CurrentClipName = clipName;
            CurrentNormalizedFrame = 0;
            PlaybackSpeedMultiplier = speed;
            OnAnimationStarted?.Invoke(clipName);
        }

        public void AdvanceFrame()
        {
            CurrentNormalizedFrame++;

            // Dispatch frame callbacks
            if (_frameEvents.TryGetValue(CurrentClipName, out var callbacks))
            {
                for (int i = 0; i < callbacks.Count; i++)
                {
                    callbacks[i].Invoke(CurrentNormalizedFrame);
                }
            }

            if (_clipTotalFrames.TryGetValue(CurrentClipName, out int totalFrames))
            {
                if (CurrentNormalizedFrame >= totalFrames)
                {
                    OnAnimationCompleted?.Invoke(CurrentClipName);
                }
            }
        }
    }
}
