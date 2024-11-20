using System;
using EpicItems.Logic.Items;

namespace EpicItems.UI.ItemPanel
{
    public interface IItemPanelController
    {
        event Action OnClose;

        void InjectData(IItemsProvider itemsProvider);
        void ShowPanel();
        void ClosePanel();
    }
}
