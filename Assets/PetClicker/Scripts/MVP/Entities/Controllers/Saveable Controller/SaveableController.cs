public class SaveableController : BaseSaveableController 
{
    public SaveableController(BaseModel model, BaseView view, BasePresenter presenter, BaseModel sharedModel = null, BaseEventBus eventBus = null) : base(model, view, presenter, sharedModel, eventBus)
    { }

    public override void SaveLayers(BaseData baseData)
    {
        if (model is BaseSaveableModel saveableModel) saveableModel.SaveLayer(baseData);
    }

    public override void LoadLayers(BaseData baseData)
    {
        if (model is BaseSaveableModel saveableModel) saveableModel.LoadLayer(baseData);
    }
}
