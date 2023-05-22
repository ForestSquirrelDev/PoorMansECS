namespace PoorMansECS.Entities {
    public class Entities {
        private readonly Dictionary<Type, List<IEntity>> _entities = new Dictionary<Type, List<IEntity>>();

        public void Add(IEntity entity) {
            var entityType = entity.GetType();
            if (!_entities.TryGetValue(entityType, out var entitiesSet)) {
                entitiesSet = new List<IEntity>();
                _entities[entityType] = entitiesSet;
            }
                
            entitiesSet.Add(entity);
        }

        public T GetFirst<T>() where T : IEntity {
            var entityType = typeof(T);
            var entitiesList = _entities[entityType];
            return (T)entitiesList[0];
        }

        public bool TryGetFirst<T>(out T entity) where T : IEntity {
            var entityType = typeof(T);
            if (!_entities.TryGetValue(entityType, out var entitiesList)) {
                entity = default;
                return false;
            }
            if (entitiesList.Count <= 0) {
                entity = default;
                return false;
            }

            entity = (T)entitiesList[0];
            return true;
        }

        public IReadOnlyList<IEntity> GetAll<T>() where T : IEntity {
            var entityType = typeof(T);
            var entitiesList = _entities[entityType];
            return entitiesList;
        }

        public bool TryGetAll<T>(out IReadOnlyList<IEntity> entitiesList) where T: IEntity {
            if (!_entities.TryGetValue(typeof(T), out var list)) {
                entitiesList = default;
                return false;
            }
            entitiesList = list;
            return true;
        }
    }
}
