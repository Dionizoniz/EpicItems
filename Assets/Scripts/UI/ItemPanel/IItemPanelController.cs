using System;
using EpicItems.Logic.Items;
using EpicItems.UI.Providers;

namespace EpicItems.UI.ItemPanel
{
    public interface IItemPanelController
    {
        event Action OnClose;

        void InjectData(IItemsProvider itemsProvider, IItemsFactory itemsFactory);
        void ShowPanel();
        void ClosePanel();
    }
}
