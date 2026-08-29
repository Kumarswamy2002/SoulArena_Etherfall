using System;

namespace SoulArena.Arenas.Events
{
    /// <summary>
    /// Dynamic Stage Interactive Trigger: IronHarbor (Crane Swing).
    /// </summary>
    public class IronHarborEventTrigger
    {
        public string EventName { get; } = "Crane Swing";
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
