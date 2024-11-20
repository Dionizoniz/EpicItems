using EpicItems.Core.Engine;

namespace EpicItems.Core.Entities.MVC
{
    public abstract class Model<TView> : ExtendedMonoBehaviour, IModel<TView> where TView : IView
    {
        protected TView _view;

        public void Initialize(TView view)
        {
            _view = view;
        }
    }
}
