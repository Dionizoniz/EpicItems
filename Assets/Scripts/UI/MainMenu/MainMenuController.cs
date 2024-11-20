using EpicItems.Core.Entities.MVC;
using EpicItems.Core.Providers;
using EpicItems.Logic.Items;

namespace EpicItems.UI.MainMenu
{
    public class MainMenuController : Controller<MainMenuModel, MainMenuView>, IMainMenuController
    {
        private IItemsProvider _itemsProvider;
        private IExitGameProvider _exitGameProvider;

        public void InjectData(IItemsProvider itemsProvider, IExitGameProvider exitGameProvider)
        {
            _itemsProvider = itemsProvider;
            _exitGameProvider = exitGameProvider;

            _view.InjectData(_itemsProvider);
            _model.InjectData(_exitGameProvider);
        }

        public void ShowShop()
        {
            _view.ShowShop();
        }

        public void ShowInventory()
        {
            _view.ShowInventory();
        }

        public void ExitGame()
        {
            _model.ExitGame();
        }
    }
}
