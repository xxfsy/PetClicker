public class ClickController : BaseController
{
    private IClickableModel _clickableModel => _model as IClickableModel;

    private IClickableView _clickableView => _view as IClickableView;

    private IClickablePresenter _clickablePresenter => _presenter as IClickablePresenter;

    public ClickController(BaseModel model, BaseView view, BasePresenter presenter) : base(model, view, presenter)
    {}

    public override void InitLayers()
    {
        throw new System.NotImplementedException();
    }
}
