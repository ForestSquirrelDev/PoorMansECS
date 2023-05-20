namespace PoorMansECS.Systems {
    public interface ISystemEventListener {
        public void ReceiveEvent<T>(T systemEvent) where T : ISystemEvent;
    }
}
