using System;
using System.Collections.Generic;
using SoulArena.Core;
using SoulArena.Combat;

namespace SoulArena.Characters.Animations
{
    /// <summary>
    /// Animation Frame Dispatcher & State Evaluator for Nox Arden (Riftborn).
    /// Synchronizes Unity Mecanim animation clips with discrete 60 FPS combat frame data.
    /// </summary>
    public class NoxArdenAnimationController
    {
        public int FighterId { get; private set; }
        public string CurrentClipName { get; private set; } = "NoxArden_Idle";
        public int CurrentNormalizedFrame { get; private set; } = 0;
        public float PlaybackSpeedMultiplier { get; set; } = 1.0f;
        public bool IsTransitioning { get; private set; } = false;

        private readonly Dictionary<string, int> _clipTotalFrames = new Dictionary<string, int>();
        private readonly Dictionary<string, List<Action<int>>> _frameEvents = new Dictionary<string, List<Action<int>>>();

        public event Action<string> OnAnimationStarted;
        public event Action<string> OnAnimationCompleted;
        public event Action<string, int> OnHitboxWindowActivated;
        public event Action<string, int> OnHitboxWindowDeactivated;

        public NoxArdenAnimationController(int fighterId)
        {
            FighterId = fighterId;
            InitializeClipDatabase();
            RegisterFrameEvents();
        }

        private void InitializeClipDatabase()
        {
            _clipTotalFrames["NoxArden_Idle"] = 60;
            _clipTotalFrames["NoxArden_MoveForward"] = 30;
            _clipTotalFrames["NoxArden_MoveBackward"] = 30;
            _clipTotalFrames["NoxArden_DashForward"] = 18;
            _clipTotalFrames["NoxArden_DashBackward"] = 18;
            _clipTotalFrames["NoxArden_JumpStart"] = 6;
            _clipTotalFrames["NoxArden_JumpLoop"] = 30;
            _clipTotalFrames["NoxArden_JumpLand"] = 8;
            _clipTotalFrames["NoxArden_GuardStart"] = 4;
            _clipTotalFrames["NoxArden_GuardHold"] = 60;
            _clipTotalFrames["NoxArden_ParryAction"] = 24;
            _clipTotalFrames["NoxArden_HitStunLight"] = 14;
            _clipTotalFrames["NoxArden_HitStunHeavy"] = 28;
            _clipTotalFrames["NoxArden_Knockdown"] = 45;
            _clipTotalFrames["NoxArden_GetUp"] = 20;

            // Attack Clips
            _clipTotalFrames["NoxArden_Attack_Light1"] = 14;
            _clipTotalFrames["NoxArden_Attack_Light2"] = 16;
            _clipTotalFrames["NoxArden_Attack_Light3"] = 20;
            _clipTotalFrames["NoxArden_Attack_Heavy"] = 34;
            _clipTotalFrames["NoxArden_Attack_Launcher"] = 27;
            _clipTotalFrames["NoxArden_Air_Strike"] = 18;
            _clipTotalFrames["NoxArden_Ability1"] = 26;
            _clipTotalFrames["NoxArden_Ability2"] = 32;
            _clipTotalFrames["NoxArden_Ability3"] = 28;
            _clipTotalFrames["NoxArden_Ultimate"] = 72;
        }

        private void RegisterFrameEvents()
        {
            // Bind hitbox active windows to exact animation frames
            RegisterClipEvent("NoxArden_Attack_Light1", (frame) =>
            {
                if (frame == 4) OnHitboxWindowActivated?.Invoke("NoxArden_Attack_Light1", frame);
                if (frame == 7) OnHitboxWindowDeactivated?.Invoke("NoxArden_Attack_Light1", frame);
            });

            RegisterClipEvent("NoxArden_Attack_Light2", (frame) =>
            {
                if (frame == 5) OnHitboxWindowActivated?.Invoke("NoxArden_Attack_Light2", frame);
                if (frame == 8) OnHitboxWindowDeactivated?.Invoke("NoxArden_Attack_Light2", frame);
            });

            RegisterClipEvent("NoxArden_Attack_Light3", (frame) =>
            {
                if (frame == 6) OnHitboxWindowActivated?.Invoke("NoxArden_Attack_Light3", frame);
                if (frame == 10) OnHitboxWindowDeactivated?.Invoke("NoxArden_Attack_Light3", frame);
            });

            RegisterClipEvent("NoxArden_Attack_Heavy", (frame) =>
            {
                if (frame == 11) OnHitboxWindowActivated?.Invoke("NoxArden_Attack_Heavy", frame);
                if (frame == 16) OnHitboxWindowDeactivated?.Invoke("NoxArden_Attack_Heavy", frame);
            });

            RegisterClipEvent("NoxArden_Attack_Launcher", (frame) =>
            {
                if (frame == 8) OnHitboxWindowActivated?.Invoke("NoxArden_Attack_Launcher", frame);
                if (frame == 12) OnHitboxWindowDeactivated?.Invoke("NoxArden_Attack_Launcher", frame);
            });

            RegisterClipEvent("NoxArden_Ultimate", (frame) =>
            {
                if (frame == 18) OnHitboxWindowActivated?.Invoke("NoxArden_Ultimate", frame);
                if (frame == 36) OnHitboxWindowDeactivated?.Invoke("NoxArden_Ultimate", frame);
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
