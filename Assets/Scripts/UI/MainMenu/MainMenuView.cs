using EpicItems.Core.Entities.MVC;
using EpicItems.Logic.Items;
using EpicItems.UI.ItemPanel;
using UnityEngine;

namespace EpicItems.UI.MainMenu
{
    public class MainMenuView : View
    {
        [SerializeField]
        private ItemPanelController _itemPanelToSpawn;

        private IItemsProvider _itemsProvider;
        private IItemPanelController _spawnedItemPanel;

        public void InjectData(IItemsProvider itemsProvider)
        {
            _itemsProvider = itemsProvider;
        }

        public void ShowShop()
        {
            if (_spawnedItemPanel != null)
            {
                ShowSpawnedShopPanel();
            }
            else
            {
                SpawnShopPanel();
            }
        }

        private void ShowSpawnedShopPanel()
        {
            _spawnedItemPanel.ShowPanel();
        }

        private void SpawnShopPanel()
        {
            _spawnedItemPanel = Instantiate(_itemPanelToSpawn);
            _spawnedItemPanel.InjectData(_itemsProvider);
        }
    }
}
