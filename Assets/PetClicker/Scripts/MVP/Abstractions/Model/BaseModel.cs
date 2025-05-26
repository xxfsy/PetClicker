public abstract class BaseModel : IControllable
{
    protected BaseView _view;

    public BaseModel(BaseView view)
    {
        _view = view;
    }
}
