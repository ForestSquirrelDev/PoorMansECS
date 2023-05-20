using System.Collections;

namespace PoorMansECS.Entities {
    public class Entities : IEnumerable<IEntity> {
        private readonly List<IEntity> _entities = new List<IEntity>();

        public void Add(IEntity entity) {
            _entities.Add(entity);
        }

        public T GetFirst<T>() where T : IEntity {
            foreach (var entity in _entities) {
                if (entity is T tEntity) {
                    return tEntity;
                }
            }
            return default;
        }

        public IList<T> GetAll<T>() where T : IEntity {
            var entities = new List<T>();
            foreach (var entity in _entities) {
                if (entity is T tEntity) {
                    entities.Add(tEntity);
                }
            }
            return entities;
        }

        public IEnumerator<IEntity> GetEnumerator() {
            return ((IEnumerable<IEntity>)_entities).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return ((IEnumerable)_entities).GetEnumerator();
        }
    }
}
