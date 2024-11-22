using System;
using EpicItems.Core.Entities.MVC;
using EpicItems.Logic.Items;
using UnityEngine;

namespace EpicItems.UI.ItemPanel
{
    public class ItemPanelController : Controller<ItemPanelModel, ItemPanelView>, IItemPanelController
    {
        public event Action OnClose = delegate { };

        private IItemsProvider _itemsProvider;

        // TEST CODE
        

        public void InjectData(IItemsProvider itemsProvider)
        {
            _itemsProvider = itemsProvider;

            _view.InjectData(_itemsProvider);
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
