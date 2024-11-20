using EpicItems.Core.Providers;
using EpicItems.Logic.Items;

namespace EpicItems.Logic.Installers
{
    public interface IMainMenuLogicInstaller
    {
        IItemsProvider ItemsProvider { get; }
        IExitGameProvider ExitGameProvider { get; }
    }
}
