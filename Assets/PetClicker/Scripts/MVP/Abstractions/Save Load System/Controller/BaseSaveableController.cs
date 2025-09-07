public abstract class BaseSaveableController : BaseController // может тоже сделать его абстрактным классом который наследуется от baseController, чтобы мы не могли ничего кроме контроллера прокинуть в менеджер.
{
    public BaseSaveableController(BaseModel model, BaseView view, BasePresenter presenter, BaseModel sharedModel = null, BaseEventBus eventBus = null) : base(model, view, presenter, sharedModel, eventBus)
    {}

    public abstract void SaveLayers(BaseData baseData);

    public abstract void LoadLayers(BaseData baseData);
}
