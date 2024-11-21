using System;

namespace EpicItems.Core.Entities.Installers
{
    public interface IInstaller
    {
        event Action OnSpawnFinish;
    }
}
