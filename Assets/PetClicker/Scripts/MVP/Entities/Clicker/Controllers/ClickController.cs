public class ClickController : BaseController, ISaveableController
{
    public ClickController(BaseModel model, BaseView view, BasePresenter presenter, BaseSharedModel sharedModel = null) : base(model, view, presenter, sharedModel)
    { }

    public override void InitializeLayers()
    {
        model.Initialize(view);

        view.Initialize(presenter);
        if (view is IUsingSharedModelLayer viewWithSharedModel && sharedModel != null) viewWithSharedModel.SetSharedModel(sharedModel);

        presenter.Initialize(model);
        if (presenter is IUsingSharedModelLayer presenterWithSharedModel && sharedModel != null) presenterWithSharedModel.SetSharedModel(sharedModel);
    }

    public void SaveLayers(BaseData baseData)
    {
        if (model is ISaveableLayer saveableModel) saveableModel.SaveLayer(baseData);
    }

    public void LoadLayers(BaseData baseData)
    {
        if (model is ISaveableLayer saveableModel) saveableModel.LoadLayer(baseData);
    }
}
