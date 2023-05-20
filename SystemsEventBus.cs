namespace PoorMansECS.Systems {
    public class SystemsEventBus {
        private readonly Dictionary<Type, HashSet<ISystemEventListener>> _eventListeners 
            = new Dictionary<Type, HashSet<ISystemEventListener>>();

        public void Subscribe<T>(ISystemEventListener listener) where T : ISystemEvent {
            var eventType = typeof(T);
            if (!_eventListeners.ContainsKey(eventType))
                _eventListeners[eventType] = new HashSet<ISystemEventListener>();
            _eventListeners[eventType].Add(listener);
        }

        public void SendEvent<T>(T systemEvent) where T : ISystemEvent {
            if (!_eventListeners.TryGetValue(typeof(T), out var listeners))
                return;
            foreach (var listener in listeners) {
                listener.ReceiveEvent(systemEvent);
            }
        }
    }
}
