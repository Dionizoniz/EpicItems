using EpicItems.Core.Entities.MVC;
using EpicItems.Core.Providers;
using EpicItems.Logic.Items;
using EpicItems.UI.Providers;

namespace EpicItems.UI.MainMenu
{
    public class MainMenuController : Controller<MainMenuModel, MainMenuView>, IMainMenuController
    {
        private IItemsProvider _itemsProvider;
        private IExitGameProvider _exitGameProvider;
        private IItemsFactory _itemsFactory;

        public void InjectData(
                IItemsProvider itemsProvider, IExitGameProvider exitGameProvider, IItemsFactory itemsFactory)
        {
            _itemsProvider = itemsProvider;
            _exitGameProvider = exitGameProvider;
            _itemsFactory = itemsFactory;

            _view.InjectData(_itemsProvider, _itemsFactory);
            _model.InjectData(_exitGameProvider);
        }

        public void ShowShop()
        {
            _view.ShowShop();
        }

        public void ExitGame()
        {
            _model.ExitGame();
        }
    }
}
