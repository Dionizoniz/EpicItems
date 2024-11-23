using EpicItems.UI.ItemPanel;
using UnityEngine;

namespace EpicItems.UI.Providers
{
    public interface IItemsFactory
    {
        ItemController CreateItemInstance(ItemController itemPrefab, Transform itemsRoot);
        void ReturnItemInstance(ItemController item);
    }
}
