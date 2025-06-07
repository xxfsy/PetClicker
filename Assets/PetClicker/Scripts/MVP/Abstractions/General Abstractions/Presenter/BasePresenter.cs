public abstract class BasePresenter 
{
    protected BaseModel model;

    public void Initialize(BaseModel model)
    {
        this.model = model;
    }
}
