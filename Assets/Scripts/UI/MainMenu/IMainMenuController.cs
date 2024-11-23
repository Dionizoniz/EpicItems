using EpicItems.Core.Providers;
using EpicItems.Logic.Items;
using EpicItems.UI.Providers;

namespace EpicItems.UI.MainMenu
{
    public interface IMainMenuController
    {
        void InjectData(IItemsProvider itemsProvider, IExitGameProvider exitGameProvider, IItemsFactory itemsFactory);
    }
}
