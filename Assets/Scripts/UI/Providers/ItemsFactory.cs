using System.Collections.Generic;
using EpicItems.UI.ItemPanel;
using UnityEngine;

namespace EpicItems.UI.Providers
{
    public class ItemsFactory : IItemsFactory
    {
        private readonly Stack<ItemController> _itemsPool = new();

        public ItemController CreateItemInstance(ItemController itemPrefab, Transform itemsRoot)
        {
            ItemController item = _itemsPool.Count > 0 ? _itemsPool.Pop() : Object.Instantiate(itemPrefab, itemsRoot);
            item._gameObject.SetActive(true);

            return item;
        }

        public void ReturnItemInstance(ItemController item)
        {
            item._gameObject.SetActive(false);
            _itemsPool.Push(item);
        }
    }
}
