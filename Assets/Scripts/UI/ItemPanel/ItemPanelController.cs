using EpicItems.Core.Entities.MVC;
using EpicItems.Logic.Items;

namespace EpicItems.UI.ItemPanel
{
    public class ItemPanelController : Controller<ItemPanelModel, ItemPanelView>, IItemPanelController
    {
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
        }
    }
}
