using System.Collections.Generic;
using EpicItems.Core.DataServer;
using EpicItems.Core.Entities.MVC;
using UnityEngine;
using UnityEngine.UI;

namespace EpicItems.UI.ItemPanel
{
    public class ItemPanelView : View
    {
        [SerializeField]
        private ItemController _itemToSpawn;
        [SerializeField]
        private Transform _root;

        [SerializeField]
        private Button _previousPageButton;
        [SerializeField]
        private Button _nextPageButton;

        private readonly List<ItemController> _spawnedItems = new();

        public void ShowPanel()
        {
            _gameObject.SetActive(true);
        }

        public void SpawnItemsFor(int pageIndex, int pageItemsCount, IList<DataItem> items)
        {
            int minIndex = pageIndex * pageItemsCount;
            int maxIndex = minIndex + pageItemsCount;

            for (int i = minIndex; i < maxIndex && i < items.Count; i++)
            {
                SpawnItem(items[i], i);
            }

            UpdatePreviousPageButton(pageIndex);
            UpdateNextPageButton(maxIndex, items.Count);
        }

        private void SpawnItem(DataItem item, int itemIndex)
        {
            ItemController spawnedItem = Instantiate(_itemToSpawn, _root);
            spawnedItem.Initialize(itemIndex + 1, item);
            _spawnedItems.Add(spawnedItem);
        }

        private void UpdatePreviousPageButton(int pageIndex)
        {
            _previousPageButton.interactable = pageIndex > 0;
        }

        private void UpdateNextPageButton(int maxIndex, int itemsCount)
        {
            _nextPageButton.interactable = maxIndex < itemsCount;
        }

        public void ClosePanel()
        {
            _gameObject.SetActive(false);
            ClearSpawnedItems();
        }

        private void ClearSpawnedItems()
        {
            foreach (var item in _spawnedItems)
            {
                Destroy(item.gameObject); // Return to pool
            }

            _spawnedItems.Clear();
        }
    }
}
