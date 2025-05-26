public abstract class BasePresenter : IControllable
{
    protected BaseModel _model;

    public BasePresenter(BaseModel model)
    {
        _model = model;
    }
}
