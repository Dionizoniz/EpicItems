using EpicItems.Core.Entities.MVC;
using EpicItems.Core.Providers;
using EpicItems.Logic.Items;

namespace EpicItems.UI.MainMenu
{
    public class MainMenuController : Controller<MainMenuModel, MainMenuView>, IMainMenuController
    {
        private IItemsProvider _itemsProvider;
        private ExitGameProvider _exitGameProvider;

        public void InjectData(IItemsProvider itemsProvider, ExitGameProvider exitGameProvider)
        {
            _itemsProvider = itemsProvider;
            _exitGameProvider = exitGameProvider;
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
