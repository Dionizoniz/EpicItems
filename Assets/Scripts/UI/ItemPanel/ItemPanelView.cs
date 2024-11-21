using EpicItems.Core.Entities.MVC;

namespace EpicItems.UI.ItemPanel
{
    public class ItemPanelView : View
    {
        public void ShowPanel()
        {
            _gameObject.SetActive(true);
        }

        public void ClosePanel()
        {
            _gameObject.SetActive(false);
        }
    }
}
