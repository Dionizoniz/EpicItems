using EpicItems.Core.Entities.MVC;

namespace EpicItems.UI.ItemPanel
{
    public class ItemPanelView : View
    {
        public void ClosePanel()
        {
            Destroy(_gameObject);
        }
    }
}
