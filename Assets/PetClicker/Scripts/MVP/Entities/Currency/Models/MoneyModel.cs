using System;

public class MoneyModel : SharedModel, ICurrencySharedModel
{
    public int MoneyValue { get; private set; }

    public override event Action<string> ViewsNotify;

    public void SetNewMoneyValue(int newValue)
    {
        MoneyValue = newValue;

        ViewsNotify?.Invoke(MoneyValue.ToString());
    }
}
