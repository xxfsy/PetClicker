public class ClickController : BaseController
{
    //private IClickableModel _clickableModel => model as IClickableModel;

    //private IClickableView _clickableView => view as IClickableView;

    //private IClickablePresenter _clickablePresenter => presenter as IClickablePresenter;

    // мб удалить это сверху ведь не пользуюсь вроде бы этим

    public ClickController(BaseModel model, BaseView view, BasePresenter presenter, SharedModel sharedModel) : base(model, view, presenter, sharedModel)
    { }

    public override void InitLayers()
    {
        model.Initialize(view);

        view.Initialize(presenter);
        if (view is IUsingSharedModel viewWithSharedModel && sharedModel != null) viewWithSharedModel.SetSharedModel(sharedModel);

        presenter.Initialize(model);
        if (presenter is IUsingSharedModel presenterWithSharedModel && sharedModel != null) presenterWithSharedModel.SetSharedModel(sharedModel);
    }
}
