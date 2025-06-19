public class ClickController : BaseController, ISaveableMVPController
{
    public ClickController(BaseModel model, BaseView view, BasePresenter presenter, BaseSharedModel sharedModel = null) : base(model, view, presenter, sharedModel)
    { }

    public override void InitializeLayers()
    {
        model.Initialize(view);

        view.Initialize(presenter);
        if (view is IUsingSharedModelView usingSharedModelView && sharedModel != null) sharedModel.AddNewView(usingSharedModelView);

        presenter.Initialize(model);
        if (presenter is IUsingSharedModelPresenter usingSharedModelPresenter && sharedModel != null) usingSharedModelPresenter.SetSharedModel(sharedModel);
    }

    public void SaveLayers(BaseData baseData)
    {
        if (model is ISaveableMVPLayer saveableModel) saveableModel.SaveLayer(baseData);
    }

    public void LoadLayers(BaseData baseData)
    {
        if (model is ISaveableMVPLayer saveableModel) saveableModel.LoadLayer(baseData);
    }
}
