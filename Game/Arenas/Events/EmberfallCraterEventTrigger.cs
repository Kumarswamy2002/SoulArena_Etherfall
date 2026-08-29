using System;

namespace SoulArena.Arenas.Events
{
    /// <summary>
    /// Dynamic Stage Interactive Trigger: EmberfallCrater (Lava Geyser Eruption).
    /// </summary>
    public class EmberfallCraterEventTrigger
    {
        public string EventName { get; } = "Lava Geyser Eruption";
        public bool HasFired { get; private set; } = false;

        public event Action<string> OnEventTriggered;

        public void Trigger()
        {
            HasFired = true;
            OnEventTriggered?.Invoke(EventName);
        }

        public void Reset()
        {
            HasFired = false;
        }
    }
}
