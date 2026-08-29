using System;

namespace SoulArena.Arenas.Events
{
    /// <summary>
    /// Dynamic Stage Interactive Trigger: RiftObservatory (Gravity Pulse).
    /// </summary>
    public class RiftObservatoryEventTrigger
    {
        public string EventName { get; } = "Gravity Pulse";
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
