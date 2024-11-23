using EpicItems.UI.ItemPanel;
using UnityEngine;

namespace EpicItems.UI.Providers
{
    public interface IItemsFactory
    {
        ItemController CreateArrowInstance(ItemController itemPrefab, Transform itemsRoot);
        void ReturnArrowInstance(ItemController item);
    }
}
