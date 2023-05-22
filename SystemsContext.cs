namespace PoorMansECS.Systems {
    public class SystemsContext {
        public Entities.Entities Entities { get; }
        public SystemsEventBus EventBus { get; }

        public SystemsContext(Entities.Entities entities, SystemsEventBus eventBus) {
            Entities = entities;
            EventBus = eventBus;
        }
    }
}
