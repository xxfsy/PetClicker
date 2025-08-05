using System;

public class AutoClickerPresenter : BasePresenter, IUsingSharedModelPresenter, ITickable
{
    private IAutoClickerModel _autoClickerModel => model as IAutoClickerModel;

    private BaseModel _moneySharedModel;

    public float TickCooldownInSeconds { get; private set; }

    public void SetSharedModel(BaseModel sharedModel)
    {
        _moneySharedModel = sharedModel;
    }

    public void SetTickCooldown(float tickCooldownInSeconds)
    {
        TickCooldownInSeconds = tickCooldownInSeconds;
    }

    public void UpdateSharedModel()
    {
        if (_moneySharedModel is ICurrencySharedModel currencySharedModel)
        {
            int newValue = currencySharedModel.MoneyValue;

            newValue += _autoClickerModel.IncomePerSecond;

            currencySharedModel.SetNewMoneyValue(newValue);
        }
        else
        {
            throw new InvalidCastException("Expected ICurrencySharedModel, but received something else.");
        }
    }

    public void Tick()
    {
        UpdateSharedModel();
    }
}
