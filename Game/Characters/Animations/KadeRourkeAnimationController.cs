using System;
using System.Collections.Generic;
using SoulArena.Core;
using SoulArena.Combat;

namespace SoulArena.Characters.Animations
{
    /// <summary>
    /// Animation Frame Dispatcher & State Evaluator for Kade Rourke (Iron Marauder).
    /// Synchronizes Unity Mecanim animation clips with discrete 60 FPS combat frame data.
    /// </summary>
    public class KadeRourkeAnimationController
    {
        public int FighterId { get; private set; }
        public string CurrentClipName { get; private set; } = "KadeRourke_Idle";
        public int CurrentNormalizedFrame { get; private set; } = 0;
        public float PlaybackSpeedMultiplier { get; set; } = 1.0f;
        public bool IsTransitioning { get; private set; } = false;

        private readonly Dictionary<string, int> _clipTotalFrames = new Dictionary<string, int>();
        private readonly Dictionary<string, List<Action<int>>> _frameEvents = new Dictionary<string, List<Action<int>>>();

        public event Action<string> OnAnimationStarted;
        public event Action<string> OnAnimationCompleted;
        public event Action<string, int> OnHitboxWindowActivated;
        public event Action<string, int> OnHitboxWindowDeactivated;

        public KadeRourkeAnimationController(int fighterId)
        {
            FighterId = fighterId;
            InitializeClipDatabase();
            RegisterFrameEvents();
        }

        private void InitializeClipDatabase()
        {
            _clipTotalFrames["KadeRourke_Idle"] = 60;
            _clipTotalFrames["KadeRourke_MoveForward"] = 30;
            _clipTotalFrames["KadeRourke_MoveBackward"] = 30;
            _clipTotalFrames["KadeRourke_DashForward"] = 18;
            _clipTotalFrames["KadeRourke_DashBackward"] = 18;
            _clipTotalFrames["KadeRourke_JumpStart"] = 6;
            _clipTotalFrames["KadeRourke_JumpLoop"] = 30;
            _clipTotalFrames["KadeRourke_JumpLand"] = 8;
            _clipTotalFrames["KadeRourke_GuardStart"] = 4;
            _clipTotalFrames["KadeRourke_GuardHold"] = 60;
            _clipTotalFrames["KadeRourke_ParryAction"] = 24;
            _clipTotalFrames["KadeRourke_HitStunLight"] = 14;
            _clipTotalFrames["KadeRourke_HitStunHeavy"] = 28;
            _clipTotalFrames["KadeRourke_Knockdown"] = 45;
            _clipTotalFrames["KadeRourke_GetUp"] = 20;

            // Attack Clips
            _clipTotalFrames["KadeRourke_Attack_Light1"] = 14;
            _clipTotalFrames["KadeRourke_Attack_Light2"] = 16;
            _clipTotalFrames["KadeRourke_Attack_Light3"] = 20;
            _clipTotalFrames["KadeRourke_Attack_Heavy"] = 34;
            _clipTotalFrames["KadeRourke_Attack_Launcher"] = 27;
            _clipTotalFrames["KadeRourke_Air_Strike"] = 18;
            _clipTotalFrames["KadeRourke_Ability1"] = 26;
            _clipTotalFrames["KadeRourke_Ability2"] = 32;
            _clipTotalFrames["KadeRourke_Ability3"] = 28;
            _clipTotalFrames["KadeRourke_Ultimate"] = 72;
        }

        private void RegisterFrameEvents()
        {
            // Bind hitbox active windows to exact animation frames
            RegisterClipEvent("KadeRourke_Attack_Light1", (frame) =>
            {
                if (frame == 4) OnHitboxWindowActivated?.Invoke("KadeRourke_Attack_Light1", frame);
                if (frame == 7) OnHitboxWindowDeactivated?.Invoke("KadeRourke_Attack_Light1", frame);
            });

            RegisterClipEvent("KadeRourke_Attack_Light2", (frame) =>
            {
                if (frame == 5) OnHitboxWindowActivated?.Invoke("KadeRourke_Attack_Light2", frame);
                if (frame == 8) OnHitboxWindowDeactivated?.Invoke("KadeRourke_Attack_Light2", frame);
            });

            RegisterClipEvent("KadeRourke_Attack_Light3", (frame) =>
            {
                if (frame == 6) OnHitboxWindowActivated?.Invoke("KadeRourke_Attack_Light3", frame);
                if (frame == 10) OnHitboxWindowDeactivated?.Invoke("KadeRourke_Attack_Light3", frame);
            });

            RegisterClipEvent("KadeRourke_Attack_Heavy", (frame) =>
            {
                if (frame == 11) OnHitboxWindowActivated?.Invoke("KadeRourke_Attack_Heavy", frame);
                if (frame == 16) OnHitboxWindowDeactivated?.Invoke("KadeRourke_Attack_Heavy", frame);
            });

            RegisterClipEvent("KadeRourke_Attack_Launcher", (frame) =>
            {
                if (frame == 8) OnHitboxWindowActivated?.Invoke("KadeRourke_Attack_Launcher", frame);
                if (frame == 12) OnHitboxWindowDeactivated?.Invoke("KadeRourke_Attack_Launcher", frame);
            });

            RegisterClipEvent("KadeRourke_Ultimate", (frame) =>
            {
                if (frame == 18) OnHitboxWindowActivated?.Invoke("KadeRourke_Ultimate", frame);
                if (frame == 36) OnHitboxWindowDeactivated?.Invoke("KadeRourke_Ultimate", frame);
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
