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

        private void Awake()
        {
            SpawnSystems();
            CreateInstances();
        }

        private void SpawnSystems()
        {
            _mainMenu = Instantiate(_mainMenuControllerToSpawn);
        }

        private void CreateInstances()
        {
        }

        protected override void Start()
        {
            InitializeSystems();
            base.Start();
        }

        private void InitializeSystems()
        {
            _mainMenu.InjectData(spawnedLogicInstaller.ItemsProvider, spawnedLogicInstaller.ExitGameProvider);
        }
    }
}
