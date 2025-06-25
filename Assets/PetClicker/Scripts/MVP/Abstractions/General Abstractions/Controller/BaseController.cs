public abstract class BaseController
{
    protected BaseModel model { get; private set; }

    protected BaseView view { get; private set; }

    protected BasePresenter presenter { get; private set; }

    protected BaseModel sharedModel { get; private set; } //nullable

    public BaseController(BaseModel model, BaseView view, BasePresenter presenter, BaseModel sharedModel)
    {
        this.model = model;
        this.view = view;
        this.presenter = presenter;
        this.sharedModel = sharedModel;
    }

    public virtual void InitializeLayers()
    {
        model.Initialize(view);

        view.Initialize(presenter);
        //if (view is ISharedModelView usingSharedModelView && sharedModel != null) sharedModel.AddNewView(usingSharedModelView);

        presenter.Initialize(model);
        if (presenter is IUsingSharedModelPresenter usingSharedModelPresenter && sharedModel != null) usingSharedModelPresenter.SetSharedModel(sharedModel);
    }
}
