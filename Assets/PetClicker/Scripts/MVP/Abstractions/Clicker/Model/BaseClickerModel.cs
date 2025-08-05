public abstract class BaseClickerModel : BaseModel
{
    public int ClicksCount { get; protected set; }

    public abstract void SetNewValueAfterClick(int newValue);
}
