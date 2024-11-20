using EpicItems.Core.Entities.Installers;
using EpicItems.Logic.Items;
using UnityEngine;
using UnityEngine.EventSystems;

namespace EpicItems.Logic.Installer
{
    public class MainMenuLogicInstaller : BaseInstaller, IMainMenuLogicInstaller
    {
        [SerializeField]
        private EventSystem _eventSystem;
        [SerializeField]
        private Camera _camera;

        private IItemsProvider _itemsProvider;

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
            _itemsProvider = new ItemsProvider();
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
