using System;

namespace SoulArena.Arenas.Events
{
    /// <summary>
    /// Dynamic Stage Interactive Trigger: SoulforgeColiseum (Divine Ether Flash).
    /// </summary>
    public class SoulforgeColiseumEventTrigger
    {
        public string EventName { get; } = "Divine Ether Flash";
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
