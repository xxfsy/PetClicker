public class SaveableController : BaseController, ISaveableMVPController
{
    public SaveableController(BaseModel model, BaseView view, BasePresenter presenter, BaseSharedModel sharedModel = null) : base(model, view, presenter, sharedModel)
    { }

    public void SaveLayers(BaseData baseData)
    {
        if (model is ISaveableMVPLayer saveableModel) saveableModel.SaveLayer(baseData);
    }

    public void LoadLayers(BaseData baseData)
    {
        if (model is ISaveableMVPLayer saveableModel) saveableModel.LoadLayer(baseData);
    }
}
