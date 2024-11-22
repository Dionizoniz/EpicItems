using EpicItems.Core.Entities.MVC;
using EpicItems.Logic.Items;

namespace EpicItems.UI.ItemPanel
{
    public class ItemPanelModel : Model<ItemPanelView>
    {
        private const int ITEMS_PER_PAGE = 5;

        private IItemsProvider _itemsProvider;
        private int _currentPageIndex;

        public void InjectData(IItemsProvider itemsProvider)
        {
            _itemsProvider = itemsProvider;
        }

        public void PrepareContent()
        {
            if (_itemsProvider.IsDataAvailable)
            {
                SpawnFirstPage();
            }
            else
            {
                // TODO show loading indicator
                AttachToEvents();
            }
        }

        private void SpawnFirstPage()
        {
            DetachFromEvents();

            // TODO hide loading indicator
            _currentPageIndex = 0;
            SpawnItemsForCurrentPage();
        }

        private void DetachFromEvents()
        {
            _itemsProvider.OnDataLoaded -= SpawnFirstPage;
        }

        private void SpawnItemsForCurrentPage()
        {
            _view.SpawnItemsFor(_currentPageIndex, ITEMS_PER_PAGE, _itemsProvider.Items);
        }

        private void AttachToEvents()
        {
            _itemsProvider.OnDataLoaded += SpawnFirstPage;
        }

        public void ShowNextPage()
        {
            if (_currentPageIndex * ITEMS_PER_PAGE < _itemsProvider.Items.Count)
            {
                _currentPageIndex++;
                SpawnItemsForCurrentPage();
            }
        }

        public void ShowPreviousPage()
        {
            if (_currentPageIndex > 0)
            {
                _currentPageIndex--;
                SpawnItemsForCurrentPage();
            }
        }

        public void ClosePanel()
        {
            DetachFromEvents();
        }

        private void OnDestroy()
        {
            DetachFromEvents();
        }
    }
}
