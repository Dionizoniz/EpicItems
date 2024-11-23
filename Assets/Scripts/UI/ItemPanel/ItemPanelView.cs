using System.Collections.Generic;
using EpicItems.Core.DataServer;
using EpicItems.Core.Entities.MVC;
using EpicItems.UI.Providers;
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

        [Space, SerializeField]
        private Button _previousPageButton;
        [SerializeField]
        private Button _nextPageButton;
        [SerializeField]
        private Image _loadingIndicator;

        private IItemsFactory _itemsFactory;
        private readonly List<ItemController> _spawnedItems = new();

        protected override void Awake()
        {
            base.Awake();
            HideLoadingIndicator();
        }

        public void InjectData(IItemsFactory itemsFactory)
        {
            _itemsFactory = itemsFactory;
        }

        public void ShowPanel()
        {
            _gameObject.SetActive(true);
        }

        public void SpawnItemsFor(int pageIndex, int pageItemsCount, IList<DataItem> items)
        {
            int minIndex = pageIndex * pageItemsCount;
            int maxIndex = minIndex + pageItemsCount;

            ClearSpawnedItems();

            for (int i = minIndex; i < maxIndex && i < items.Count; i++)
            {
                SpawnItem(items[i], i);
            }

            UpdatePreviousPageButton(pageIndex);
            UpdateNextPageButton(maxIndex, items.Count);
        }

        private void ClearSpawnedItems()
        {
            foreach (var item in _spawnedItems)
            {
                _itemsFactory.ReturnItemInstance(item);
            }

            _spawnedItems.Clear();
        }

        private void SpawnItem(DataItem item, int itemIndex)
        {
            ItemController spawnedItem = _itemsFactory.CreateItemInstance(_itemToSpawn, _root);
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

        public void ShowLoadingIndicator()
        {
            _loadingIndicator.gameObject.SetActive(true);
        }

        public void HideLoadingIndicator()
        {
            _loadingIndicator.gameObject.SetActive(false);
        }

        public void ClosePanel()
        {
            _gameObject.SetActive(false);
            ClearSpawnedItems();
        }
    }
}
