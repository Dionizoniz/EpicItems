using System;
using EpicItems.Core.Engine;

namespace EpicItems.Core.Entities.Installers
{
    public abstract class BaseInstaller : ExtendedMonoBehaviour, IInstaller
    {
        public event Action OnSpawnFinish = delegate { };

        protected virtual void Start()
        {
            NotifyOnSpawnFinish();
        }

        private void NotifyOnSpawnFinish()
        {
            OnSpawnFinish.Invoke();
        }
    }
}
