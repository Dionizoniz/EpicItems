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

        private void Awake()
        {
            SpawnSystems();
            CreateInstances();
        }

        private void SpawnSystems()
        {
            Instantiate(_eventSystem);
            Instantiate(_camera);
        }

        private void CreateInstances()
        {
            ItemsProvider = new ItemsProvider();
            ExitGameProvider = new ExitGameProvider();
        }

        protected override void Start()
        {
            InitializeSystems();
            base.Start();
        }

        private void InitializeSystems()
        {
        }
    }
}
