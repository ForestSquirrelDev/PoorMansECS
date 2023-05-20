using PoorMansECS.Components;

namespace PoorMansECS.Entities {
    public abstract class Entity : IEntity {
        private readonly HashSet<IComponentData> _components;

        protected Entity() {
            _components = new HashSet<IComponentData>();
        }

        public void AddComponent(IComponentData component) {
            _components.Add(component);
        }

        public void RemoveComponent<TComponent>() where TComponent: IComponentData {
            IComponentData? componentToRemove = null;
            foreach (var component in _components) {
                if (component is TComponent) {
                    componentToRemove = component;
                    break;
                }
            }
            
            if (componentToRemove != null)
                _components.Remove(componentToRemove);
        }

        public TComponent? GetComponent<TComponent>() where TComponent : IComponentData {
            foreach (var component in _components) {
                if (component is TComponent tComponent)
                    return tComponent;
            }
            return default;
        }
    }
}
