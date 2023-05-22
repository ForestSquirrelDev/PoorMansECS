using PoorMansECS.Components;

namespace PoorMansECS.Entities {
    public interface IEntity {
        public void SetComponent(IComponentData component);
        public void RemoveComponent<TComponent>() where TComponent : IComponentData;
        public TComponent? GetComponent<TComponent>() where TComponent : IComponentData;
    }
}
