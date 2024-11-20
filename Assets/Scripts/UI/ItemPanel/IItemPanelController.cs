using EpicItems.Logic.Items;

namespace EpicItems.UI.ItemPanel
{
    public interface IItemPanelController
    {
        void InjectData(IItemsProvider itemsProvider);
        void ShowPanel();
        void ClosePanel();
    }
}
