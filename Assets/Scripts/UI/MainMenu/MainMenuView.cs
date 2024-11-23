using EpicItems.Core.Entities.MVC;
using EpicItems.Logic.Items;
using EpicItems.UI.ItemPanel;
using EpicItems.UI.Providers;
using UnityEngine;

namespace EpicItems.UI.MainMenu
{
    public class MainMenuView : View
    {
        [SerializeField]
        private ItemPanelController _itemPanelToSpawn;

        [Space, SerializeField]
        private GameObject _content;

        private IItemsProvider _itemsProvider;
        private IItemsFactory _itemsFactory;
        private IItemPanelController _spawnedItemPanel;

        public void InjectData(IItemsProvider itemsProvider, IItemsFactory itemsFactory)
        {
            _itemsProvider = itemsProvider;
            _itemsFactory = itemsFactory;
        }

        public void ShowShop()
        {
            if (_spawnedItemPanel == null)
            {
                SpawnShopPanel();
            }

            ShowSpawnedShopPanel();
            HideContent();
        }

        private void ShowSpawnedShopPanel()
        {
            _spawnedItemPanel.ShowPanel();
        }

        private void SpawnShopPanel()
        {
            _spawnedItemPanel = Instantiate(_itemPanelToSpawn);
            _spawnedItemPanel.InjectData(_itemsProvider, _itemsFactory);

            _spawnedItemPanel.OnClose += ShowContent;
        }

        private void ShowContent()
        {
            _content.SetActive(true);
        }

        private void HideContent()
        {
            _content.SetActive(false);
        }

        private void OnDisable()
        {
            if (_spawnedItemPanel != null)
            {
                _spawnedItemPanel.OnClose -= ShowContent;
            }
        }
    }
}
