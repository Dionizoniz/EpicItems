using EpicItems.Core.Entities.Installers;
using EpicItems.Core.Providers;
using EpicItems.Logic.Items;
using UnityEngine;
using UnityEngine.EventSystems;

namespace EpicItems.Logic.Installers
{
    public class MainMenuLogicInstaller : BaseInstaller, IMainMenuLogicInstaller
    {
        [SerializeField]
        private EventSystem _eventSystem;
        [SerializeField]
        private Camera _camera;

        public IItemsProvider ItemsProvider { get; private set; }
        public IExitGameProvider ExitGameProvider { get; private set; }

        protected override void SpawnSystems()
        {
            base.SpawnSystems();

            Instantiate(_eventSystem);
            Instantiate(_camera);
        }

        protected override void CreateInstances()
        {
            base.CreateInstances();

            ItemsProvider = new ItemsProvider();
            ExitGameProvider = new ExitGameProvider();
        }
    }
}
