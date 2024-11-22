using System;
using EpicItems.Core.Entities.MVC;
using EpicItems.Logic.Items;

namespace EpicItems.UI.ItemPanel
{
    public class ItemPanelController : Controller<ItemPanelModel, ItemPanelView>, IItemPanelController
    {
        public event Action OnClose = delegate { };

        private IItemsProvider _itemsProvider;

        public void InjectData(IItemsProvider itemsProvider)
        {
            _itemsProvider = itemsProvider;

            _model.InjectData(_itemsProvider);
        }

        public void ShowPanel()
        {
            _view.ShowPanel();
            _model.PrepareContent();
        }

        public void ClosePanel()
        {
            _view.ClosePanel();
            _model.ClosePanel();
            OnClose.Invoke();
        }

        public void ShowNextPage()
        {
            _model.ShowNextPage();
        }

        public void ShowPreviousPage()
        {
            _model.ShowPreviousPage();
        }
    }
}
