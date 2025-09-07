public abstract class BaseClickerModel : BaseSaveableModel
{
    protected BaseClickerView clickerView => view as BaseClickerView; 

    public int ClicksCount { get; protected set; }

    public int IncomePerClick { get; protected set; }

    public abstract void SetNewClicksCountValue(int newValue);

    public abstract void SetNewValueForIncomePerClick(int newValue);
}
