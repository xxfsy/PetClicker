public abstract class BaseAutoClickerModel : BaseSaveableModel
{
    protected BaseAutoClickerView autoClickerView => view as BaseAutoClickerView; 

    public int IncomePerSecond { get; protected set; }

    public abstract void SetNewValueForIncomePerSecond(int newValue);
}
