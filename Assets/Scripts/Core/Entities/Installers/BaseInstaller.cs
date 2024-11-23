using EpicItems.Core.Engine;

namespace EpicItems.Core.Entities.Installers
{
    public abstract class BaseInstaller : ExtendedMonoBehaviour
    {
        protected sealed override void Awake()
        {
            SpawnSystems();
            CreateInstances();
        }

        protected virtual void SpawnSystems()
        { }

        protected virtual void CreateInstances()
        { }

        private void Start()
        {
            InitializeSystems();
        }

        protected virtual void InitializeSystems()
        { }
    }
}
