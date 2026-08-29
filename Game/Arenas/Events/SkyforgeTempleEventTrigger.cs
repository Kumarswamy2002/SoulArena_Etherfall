using System;

namespace SoulArena.Arenas.Events
{
    /// <summary>
    /// Dynamic Stage Interactive Trigger: SkyforgeTemple (Storm Wind Surge).
    /// </summary>
    public class SkyforgeTempleEventTrigger
    {
        public string EventName { get; } = "Storm Wind Surge";
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
