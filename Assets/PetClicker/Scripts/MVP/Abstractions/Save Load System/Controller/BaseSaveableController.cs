public abstract class BaseSaveableController : BaseController 
{
    public BaseSaveableController(BaseModel model, BaseView view, BasePresenter presenter, BaseModel sharedModel = null, BaseEventBus eventBus = null) : base(model, view, presenter, sharedModel, eventBus)
    {}

    public abstract void SaveLayers(BaseData baseData);

    public abstract void LoadLayers(BaseData baseData);
}
