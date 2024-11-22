using System;
using EpicItems.Core.Entities.MVC;
using EpicItems.Logic.Items;
using UnityEngine;

namespace EpicItems.UI.ItemPanel
{
    public class ItemPanelView : View
    {
        [SerializeField]
        private ItemController _itemToSpawn;
        [SerializeField]
        private Transform _root;

        private IItemsProvider _itemsProvider;

        public void InjectData(IItemsProvider itemsProvider)
        {
            _itemsProvider = itemsProvider;
        }

        public void ShowPanel()
        {
            if (_itemsProvider.IsDataAvailable)
            {
                SpawnItems();
            }
            else
            {
                _itemsProvider.OnDataLoaded += SpawnItems;
            }

            _gameObject.SetActive(true);
        }

        private void SpawnItems()
        {
            _itemsProvider.OnDataLoaded -= SpawnItems;

            for (int i = 0; i < 5; i++)
            {
                var item = Instantiate(_itemToSpawn, _root);
                item.Initialize(i + 1, _itemsProvider.Items[i]);
            }
        }

        public void ClosePanel()
        {
            _gameObject.SetActive(false);
        }

        private void OnDestroy()
        {
            _itemsProvider.OnDataLoaded -= SpawnItems;
        }
    }
}
