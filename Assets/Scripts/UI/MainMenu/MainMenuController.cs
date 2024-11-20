using EpicItems.Core.Entities.MVC;

namespace EpicItems.UI.MainMenu
{
    public class MainMenuController : Controller<MainMenuModel, MainMenuView>, IMainMenuController
    {
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
            _view.ExitGame();
        }
    }
}
