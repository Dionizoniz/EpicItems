using UnityEngine;

namespace EpicItems.Core.Entities.MVC
{
    public abstract class Controller<TModel, TView> : BaseController, IController
            where TModel : IModel<TView>
            where TView : IView
    {
        [SerializeField]
        protected TModel _model;

        [SerializeField]
        protected TView _view;

        protected sealed override void Awake()
        {
            base.Awake();
            Initialize();
        }

        protected virtual void Initialize()
        {
            _model.Initialize(_view);
        }
    }
}
