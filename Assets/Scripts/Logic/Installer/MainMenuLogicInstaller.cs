using EpicItems.Core.Entities.Installers;

namespace EpicItems.Logic.Installer
{
    public class MainMenuLogicInstaller : BaseInstaller, IMainMenuLogicInstaller
    {
        private void Awake()
        {
            SpawnSystems();
            CreateInstances();
        }

        private void SpawnSystems()
        {
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
        }
    }
}
