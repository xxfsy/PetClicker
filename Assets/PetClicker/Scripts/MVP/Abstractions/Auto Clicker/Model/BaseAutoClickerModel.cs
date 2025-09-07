public abstract class BaseAutoClickerModel : BaseSaveableModel
{
    protected BaseAutoClickerView autoClickerView => view as BaseAutoClickerView; // мб еще так что-то вынести из реализаций как вот ссылка на слой после каста

    public int IncomePerSecond { get; protected set; }

    public abstract void SetNewValueForIncomePerSecond(int newValue);
}
