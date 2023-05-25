using PoorMansECS.Entities;
using PoorMansECS.Systems;
using System;

namespace PoorMansECS {
    public class World : IUpdateable {
        public Entities.Entities Entities { get; }

        private readonly Systems.Systems _systems;
        private readonly SystemsEventBus _eventBus;
        private readonly SystemsContext _systemsContext;

        public World() {
            Entities = new Entities.Entities();
            _eventBus = new SystemsEventBus();
            _systems = new Systems.Systems();
            _systemsContext = new SystemsContext(this, _eventBus);
        }

        public void Start() {
            _systems.Start();
        }

        public void Update(float delta) {
            _systems.Update(delta);
        }

        public T CreateSystem<T>() where T : SystemBase {
            if (_systems.TryGet<T>(out var system))
                return system;
            system = Activator.CreateInstance(typeof(T), _systemsContext) as T;
            _systems.Add(system);
            return system;
        }

        public void RemoveSystem<T>() where T : SystemBase {
            _systems.Remove<T>();
        }

        public T GetSystem<T>() where T : SystemBase {
            return _systems.Get<T>();
        }

        public T CreateEntity<T>() where T: IEntity, new() {
            var entity = new T();
            Entities.Add(entity);
            return entity;
        }

        public void Stop() {
            _systems.Stop();
        }
    }
}