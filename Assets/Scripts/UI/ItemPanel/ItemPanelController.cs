using System;
using EpicItems.Core.Entities.MVC;
using EpicItems.Logic.Items;

namespace EpicItems.UI.ItemPanel
{
    public class ItemPanelController : Controller<ItemPanelModel, ItemPanelView>, IItemPanelController
    {
        public event Action OnClose = delegate
                                      { };

        private IItemsProvider _itemsProvider;

        public void InjectData(IItemsProvider itemsProvider)
        {
            _itemsProvider = itemsProvider;
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
