public abstract class BaseCurrencySharedModel : BaseModel
{
    public int MoneyValue { get; protected set; }

    public abstract void SetNewCurrencyValue(int newValue);
}
