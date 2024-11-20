using System;
using EpicItems.Core.DataServer;
using UnityEngine;

namespace EpicItems.UI.ItemPanel
{
    [Serializable]
    public class CategoryData
    {
        [SerializeField]
        private DataItem.CategoryType _categoryType;
        [SerializeField]
        private Sprite _categorySprite;

        public DataItem.CategoryType CategoryType => _categoryType;
        public Sprite CategorySprite => _categorySprite;
    }
}
