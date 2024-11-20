using EpicItems.Core.Entities.MVC;
using EpicItems.Logic.Items;
using EpicItems.UI.ItemPanel;
using UnityEngine;

namespace EpicItems.UI.MainMenu
{
    public class MainMenuView : View
    {
        [SerializeField]
        private ItemPanelController _itemPanelToSpawn;

        private IItemsProvider _itemsProvider;

        public void InjectData(IItemsProvider itemsProvider)
        {
            _itemsProvider = itemsProvider;
        }

        public void ShowShop()
        {
            Instantiate(_itemPanelToSpawn);
        }
    }
}
