using EpicItems.Core.Entities.MVC;
using EpicItems.Core.Providers;

namespace EpicItems.UI.MainMenu
{
    public class MainMenuModel : Model<MainMenuView>
    {
        private IExitGameProvider _exitGameProvider;

        public void InjectData(IExitGameProvider exitGameProvider)
        {
            _exitGameProvider = exitGameProvider;
        }

        public void ExitGame()
        {
            _exitGameProvider.ExitGame();
        }
    }
}
