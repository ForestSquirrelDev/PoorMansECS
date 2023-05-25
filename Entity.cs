using PoorMansECS.Components;
using System;
using System.Collections.Generic;

namespace PoorMansECS.Entities {
    public abstract class Entity : IEntity {
        private readonly Dictionary<Type, IComponentData> _components = new Dictionary<Type, IComponentData>();

        public void SetComponent(IComponentData component) {
            _components[component.GetType()] = component;
        }

        public void RemoveComponent<T>() where T: IComponentData {
            _components.Remove(typeof(T));
        }

        public T GetComponent<T>() where T : IComponentData {
            return (T)_components[typeof(T)];
        }

        public bool TryGetComponent<T>(out T componentData) where T: IComponentData {
            if (_components.TryGetValue(typeof(T), out var component)) {
                componentData = (T)component;
                return true;
            }
            componentData = default;
            return false;        
        }
    }
}
