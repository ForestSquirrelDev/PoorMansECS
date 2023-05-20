using System.Collections;

namespace PoorMansECS.Systems {
    public class Systems : IUpdateable, IEnumerable<ISystem> {
        private readonly HashSet<ISystem> _systems = new HashSet<ISystem>();

        public Systems() { }

        public Systems(IEnumerable<ISystem> systems) {
            foreach (var system in systems)
                _systems.Add(system);
        }

        public void Start() {
            foreach (var system in _systems) {
                system.Start();
            }
        }

        public void Update(float deltaTime) {
            foreach (var system in _systems) {
                system.Update(deltaTime);
            }
        }

        public void Add(ISystem system) {
            _systems.Add(system);
        }

        public void Remove(ISystem system) {
            _systems.Remove(system);
        }

        public T? Get<T>() where T : ISystem {
            foreach (var system in _systems) {
                if (system is T tSystem) {
                    return tSystem;
                }
            }
            return default;
        }

        public IEnumerator<ISystem> GetEnumerator() {
            return _systems.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return ((IEnumerable)_systems).GetEnumerator();
        }
    }
}
