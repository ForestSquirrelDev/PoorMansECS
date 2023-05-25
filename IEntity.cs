using PoorMansECS.Components;

namespace PoorMansECS.Entities {
    public interface IEntity {
        void SetComponent(IComponentData component);
        void RemoveComponent<TComponent>() where TComponent : IComponentData;
        TComponent GetComponent<TComponent>() where TComponent : IComponentData;
    }
}
