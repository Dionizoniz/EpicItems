using System.Collections.Generic;
using EpicItems.Core.DataServer;
using EpicItems.Core.Entities.MVC;
using EpicItems.Logic.Items;
using UnityEngine;
using UnityEngine.UI;

namespace EpicItems.UI.ItemPanel
{
    public class ItemPanelView : View
    {
        // TODO move some code to Model
        private const int ITEMS_PER_PAGE = 5;

        [SerializeField]
        private ItemController _itemToSpawn;
        [SerializeField]
        private Transform _root;

        [SerializeField]
        private Button _previousPageButton;
        [SerializeField]
        private Button _nextPageButton;

        private IItemsProvider _itemsProvider;

        private List<ItemController> _spawnedItems = new();
        private int _currentPageIndex;

        public void InjectData(IItemsProvider itemsProvider)
        {
            _itemsProvider = itemsProvider;
        }

        public void ShowPanel()
        {
            PrepareContent();
            _gameObject.SetActive(true);
        }

        private void PrepareContent()
        {
            if (_itemsProvider.IsDataAvailable)
            {
                SpawnFirstPage();
            }
            else
            {
                _itemsProvider.OnDataLoaded += SpawnFirstPage;
            }
        }

        private void SpawnFirstPage()
        {
            _itemsProvider.OnDataLoaded -= SpawnFirstPage;
            _currentPageIndex = 0;

            SpawnItemsFor(_currentPageIndex);
        }

        private void SpawnItemsFor(int pageIndex)
        {
            IList<DataItem> items = _itemsProvider.Items;
            int minIndex = pageIndex * ITEMS_PER_PAGE;
            int maxIndex = minIndex + ITEMS_PER_PAGE;

            foreach (var item in _spawnedItems)
            {
                Destroy(item.gameObject);
            }

            _spawnedItems.Clear();

            for (int i = minIndex; i < maxIndex && i < items.Count; i++)
            {
                var item = Instantiate(_itemToSpawn, _root);
                item.Initialize(i + 1, _itemsProvider.Items[i]);
                _spawnedItems.Add(item);
            }

            _previousPageButton.interactable = pageIndex > 0;
            _nextPageButton.interactable = (_currentPageIndex + 1) * ITEMS_PER_PAGE < items.Count;
        }

        public void ClosePanel()
        {
            _gameObject.SetActive(false);
        }

        private void OnDestroy()
        {
            _itemsProvider.OnDataLoaded -= SpawnFirstPage;
        }

        public void ShowNextPage()
        {
            if (_currentPageIndex * ITEMS_PER_PAGE < _itemsProvider.Items.Count)
            {
                _currentPageIndex++;
                SpawnItemsFor(_currentPageIndex);
            }
        }

        public void ShowPreviousPage()
        {
            if (_currentPageIndex > 0)
            {
                _currentPageIndex--;
                SpawnItemsFor(_currentPageIndex);
            }
        }
    }
}
