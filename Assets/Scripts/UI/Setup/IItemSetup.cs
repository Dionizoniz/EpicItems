using EpicItems.Core.DataServer;
using UnityEngine;

namespace EpicItems.UI.Setup
{
    public interface IItemSetup
    {
        Sprite TryFindSpriteBy(DataItem.CategoryType categoryType);
    }
}
