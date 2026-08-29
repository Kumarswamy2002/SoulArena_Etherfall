using System;
using System.Collections.Generic;
using SoulArena.Core;
using SoulArena.Combat;

namespace SoulArena.Characters.Animations
{
    /// <summary>
    /// Animation Frame Dispatcher & State Evaluator for Kael Varyn (Stormbound).
    /// Synchronizes Unity Mecanim animation clips with discrete 60 FPS combat frame data.
    /// </summary>
    public class KaelVarynAnimationController
    {
        public int FighterId { get; private set; }
        public string CurrentClipName { get; private set; } = "KaelVaryn_Idle";
        public int CurrentNormalizedFrame { get; private set; } = 0;
        public float PlaybackSpeedMultiplier { get; set; } = 1.0f;
        public bool IsTransitioning { get; private set; } = false;

        private readonly Dictionary<string, int> _clipTotalFrames = new Dictionary<string, int>();
        private readonly Dictionary<string, List<Action<int>>> _frameEvents = new Dictionary<string, List<Action<int>>>();

        public event Action<string> OnAnimationStarted;
        public event Action<string> OnAnimationCompleted;
        public event Action<string, int> OnHitboxWindowActivated;
        public event Action<string, int> OnHitboxWindowDeactivated;

        public KaelVarynAnimationController(int fighterId)
        {
            FighterId = fighterId;
            InitializeClipDatabase();
            RegisterFrameEvents();
        }

        private void InitializeClipDatabase()
        {
            _clipTotalFrames["KaelVaryn_Idle"] = 60;
            _clipTotalFrames["KaelVaryn_MoveForward"] = 30;
            _clipTotalFrames["KaelVaryn_MoveBackward"] = 30;
            _clipTotalFrames["KaelVaryn_DashForward"] = 18;
            _clipTotalFrames["KaelVaryn_DashBackward"] = 18;
            _clipTotalFrames["KaelVaryn_JumpStart"] = 6;
            _clipTotalFrames["KaelVaryn_JumpLoop"] = 30;
            _clipTotalFrames["KaelVaryn_JumpLand"] = 8;
            _clipTotalFrames["KaelVaryn_GuardStart"] = 4;
            _clipTotalFrames["KaelVaryn_GuardHold"] = 60;
            _clipTotalFrames["KaelVaryn_ParryAction"] = 24;
            _clipTotalFrames["KaelVaryn_HitStunLight"] = 14;
            _clipTotalFrames["KaelVaryn_HitStunHeavy"] = 28;
            _clipTotalFrames["KaelVaryn_Knockdown"] = 45;
            _clipTotalFrames["KaelVaryn_GetUp"] = 20;

            // Attack Clips
            _clipTotalFrames["KaelVaryn_Attack_Light1"] = 14;
            _clipTotalFrames["KaelVaryn_Attack_Light2"] = 16;
            _clipTotalFrames["KaelVaryn_Attack_Light3"] = 20;
            _clipTotalFrames["KaelVaryn_Attack_Heavy"] = 34;
            _clipTotalFrames["KaelVaryn_Attack_Launcher"] = 27;
            _clipTotalFrames["KaelVaryn_Air_Strike"] = 18;
            _clipTotalFrames["KaelVaryn_Ability1"] = 26;
            _clipTotalFrames["KaelVaryn_Ability2"] = 32;
            _clipTotalFrames["KaelVaryn_Ability3"] = 28;
            _clipTotalFrames["KaelVaryn_Ultimate"] = 72;
        }

        private void RegisterFrameEvents()
        {
            // Bind hitbox active windows to exact animation frames
            RegisterClipEvent("KaelVaryn_Attack_Light1", (frame) =>
            {
                if (frame == 4) OnHitboxWindowActivated?.Invoke("KaelVaryn_Attack_Light1", frame);
                if (frame == 7) OnHitboxWindowDeactivated?.Invoke("KaelVaryn_Attack_Light1", frame);
            });

            RegisterClipEvent("KaelVaryn_Attack_Light2", (frame) =>
            {
                if (frame == 5) OnHitboxWindowActivated?.Invoke("KaelVaryn_Attack_Light2", frame);
                if (frame == 8) OnHitboxWindowDeactivated?.Invoke("KaelVaryn_Attack_Light2", frame);
            });

            RegisterClipEvent("KaelVaryn_Attack_Light3", (frame) =>
            {
                if (frame == 6) OnHitboxWindowActivated?.Invoke("KaelVaryn_Attack_Light3", frame);
                if (frame == 10) OnHitboxWindowDeactivated?.Invoke("KaelVaryn_Attack_Light3", frame);
            });

            RegisterClipEvent("KaelVaryn_Attack_Heavy", (frame) =>
            {
                if (frame == 11) OnHitboxWindowActivated?.Invoke("KaelVaryn_Attack_Heavy", frame);
                if (frame == 16) OnHitboxWindowDeactivated?.Invoke("KaelVaryn_Attack_Heavy", frame);
            });

            RegisterClipEvent("KaelVaryn_Attack_Launcher", (frame) =>
            {
                if (frame == 8) OnHitboxWindowActivated?.Invoke("KaelVaryn_Attack_Launcher", frame);
                if (frame == 12) OnHitboxWindowDeactivated?.Invoke("KaelVaryn_Attack_Launcher", frame);
            });

            RegisterClipEvent("KaelVaryn_Ultimate", (frame) =>
            {
                if (frame == 18) OnHitboxWindowActivated?.Invoke("KaelVaryn_Ultimate", frame);
                if (frame == 36) OnHitboxWindowDeactivated?.Invoke("KaelVaryn_Ultimate", frame);
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
