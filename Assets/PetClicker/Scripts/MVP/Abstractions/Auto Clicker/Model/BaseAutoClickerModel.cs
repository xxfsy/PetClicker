public abstract class BaseAutoClickerModel : BaseModel
{
    public int IncomePerSecond { get; protected set; }

    public abstract void SetNewValueForIncomePerSecond(int newValue);
}
