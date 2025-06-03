public abstract class BaseModel
{
    protected BaseView view;

    public void Initialize(BaseView view)
    {
        this.view = view;
    }
}
