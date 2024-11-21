using System;
using EpicItems.Core.Entities.MVC;
using EpicItems.Logic.Items;
using UnityEngine;

namespace EpicItems.UI.ItemPanel
{
    public class ItemPanelController : Controller<ItemPanelModel, ItemPanelView>, IItemPanelController
    {
        public event Action OnClose = delegate
                                      { };

        private IItemsProvider _itemsProvider;

        // TEST CODE
        [SerializeField]
        private ItemController _itemToSpawn;
        [SerializeField]
        private Transform _root;

        public void InjectData(IItemsProvider itemsProvider)
        {
            _itemsProvider = itemsProvider;

            // TEST CODE
            _itemsProvider.OnDataLoaded += SpawnItems;
        }

        // TEST CODE
        private void SpawnItems()
        {
            for (int i = 0; i < 5; i++)
            {
                var item = Instantiate(_itemToSpawn, _root);
                item.Initialize(i + 1, _itemsProvider.Items[i]);
            }
        }

        public void ShowPanel()
        {
            _view.ShowPanel();
        }

        public void ClosePanel()
        {
            _view.ClosePanel();
            OnClose.Invoke();
        }
    }
}
