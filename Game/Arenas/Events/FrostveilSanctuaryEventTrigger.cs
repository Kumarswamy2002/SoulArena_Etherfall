using System;

namespace SoulArena.Arenas.Events
{
    /// <summary>
    /// Dynamic Stage Interactive Trigger: FrostveilSanctuary (Blizzard Whiteout).
    /// </summary>
    public class FrostveilSanctuaryEventTrigger
    {
        public string EventName { get; } = "Blizzard Whiteout";
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
