public class SaveableController : BaseController, ISaveableMVPController
{
    public SaveableController(BaseModel model, BaseView view, BasePresenter presenter, BaseModel sharedModel = null) : base(model, view, presenter, sharedModel)
    { }

    public void SaveLayers(BaseData baseData)
    {
        if (model is ISaveableModel saveableModel) saveableModel.SaveLayer(baseData);
    }

    public void LoadLayers(BaseData baseData)
    {
        if (model is ISaveableModel saveableModel) saveableModel.LoadLayer(baseData);
    }
}
