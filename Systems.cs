namespace PoorMansECS.Systems {
    public class Systems : IUpdateable{
        private readonly Dictionary<Type, ISystem> _systems = new Dictionary<Type, ISystem>();

        public Systems() { }

        public Systems(IEnumerable<ISystem> systems) {
            foreach (var system in systems)
                _systems.Add(system.GetType(), system);
        }

        public void Start() {
            foreach (var system in _systems.Values) {
                system.Start();
            }
        }

        public void Update(float deltaTime) {
            foreach (var system in _systems.Values) {
                system.Update(deltaTime);
            }
        }

        public void Add(ISystem system) {
            _systems.Add(system.GetType(), system);
        }

        public void Remove<T>() where T: ISystem {
            _systems.Remove(typeof(T));
        }

        public T Get<T>() where T : ISystem {
            return (T)_systems[typeof(T)];
        }

        public bool TryGet<T>(out T system) where T: ISystem {
            if (_systems.TryGetValue(typeof(T), out var innerSystem)) {
                system = (T)innerSystem;
                return true;
            }
            system = default;
            return false;
        }

        public bool Contains<T>() where T: ISystem {
            return _systems.ContainsKey(typeof(T));
        }
    }
}
