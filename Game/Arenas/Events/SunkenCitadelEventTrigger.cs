using System;

namespace SoulArena.Arenas.Events
{
    /// <summary>
    /// Dynamic Stage Interactive Trigger: SunkenCitadel (Tidal Surge).
    /// </summary>
    public class SunkenCitadelEventTrigger
    {
        public string EventName { get; } = "Tidal Surge";
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
