using System;

namespace SoulArena.Arenas.Events
{
    /// <summary>
    /// Dynamic Stage Interactive Trigger: AstralGarden (Star Alignment).
    /// </summary>
    public class AstralGardenEventTrigger
    {
        public string EventName { get; } = "Star Alignment";
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
