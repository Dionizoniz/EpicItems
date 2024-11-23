using EpicItems.Core.Entities.Installers;
using EpicItems.Logic.Installers;
using EpicItems.UI.MainMenu;
using UnityEngine;

namespace EpicItems.UI.Installers
{
    public class MainMenuUiInstaller : BaseInstaller, IMainMenuUiInstaller
    {
        [SerializeField]
        private MainMenuLogicInstaller spawnedLogicInstaller;

        [Space, SerializeField]
        private MainMenuController _mainMenuControllerToSpawn;

        private MainMenuController _mainMenu;

        protected override void SpawnSystems()
        {
            base.SpawnSystems();
            _mainMenu = Instantiate(_mainMenuControllerToSpawn);
        }

        protected override void InitializeSystems()
        {
            base.InitializeSystems();
            _mainMenu.InjectData(spawnedLogicInstaller.ItemsProvider, spawnedLogicInstaller.ExitGameProvider);
        }
    }
}
