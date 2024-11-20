using EpicItems.Core.Entities.MVC;
using EpicItems.Core.Providers;

namespace EpicItems.UI.MainMenu
{
    public class MainMenuModel : Model<MainMenuView>
    {
        private ExitGameProvider _exitGameProvider;

        public void InjectData(ExitGameProvider exitGameProvider)
        {
            _exitGameProvider = exitGameProvider;
        }

        public void ExitGame()
        {
            _exitGameProvider.ExitGame();
        }
    }
}
