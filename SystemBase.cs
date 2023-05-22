﻿namespace PoorMansECS.Systems {
    public abstract class SystemBase : ISystem {
        protected readonly SystemsContext _context;

        protected SystemBase(SystemsContext context) {
            _context = context;
        }

        public void Start() {
            OnStart();
        }

        public void Update(float delta) {
            OnUpdate(delta);
        }

        protected abstract void OnStart();
        protected abstract void OnUpdate(float delta);
    }
}
