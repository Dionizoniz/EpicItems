using System.Collections.Generic;
using EpicItems.Core.DataServer;
using EpicItems.Core.Engine;
using EpicItems.UI.ItemPanel;
using UnityEngine;

namespace EpicItems.UI.Setup
{
    [CreateAssetMenu(menuName = nameof(ItemSetup), fileName = nameof(ItemSetup), order = 0)]
    public class ItemSetup : ExtendedScriptableObject, IItemSetup
    {
        [SerializeField]
        private List<CategoryData> _categories = new();

        public Sprite TryFindSpriteBy(DataItem.CategoryType categoryType)
        {
            Sprite result = null;

            foreach (CategoryData category in _categories)
            {
                if (category.CategoryType == categoryType)
                {
                    result = category.CategorySprite;
                    break;
                }
            }

            return result;
        }
    }
}
