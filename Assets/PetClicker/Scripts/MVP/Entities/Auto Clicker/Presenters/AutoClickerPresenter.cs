using System;

public class AutoClickerPresenter : BaseUsingSharedModelPresenter, ITickable
{
    private BaseAutoClickerModel _autoClickerModel => model as BaseAutoClickerModel;

    private BaseModel _moneySharedModel;

    public float TickCooldownInSeconds { get; private set; }

    public override void SetSharedModel(BaseModel sharedModel)
    {
        _moneySharedModel = sharedModel;
    }

    public void SetTickCooldown(float tickCooldownInSeconds)
    {
        TickCooldownInSeconds = tickCooldownInSeconds;
    }

    protected override void UpdateSharedModel()
    {
        if (_moneySharedModel is BaseCurrencySharedModel currencySharedModel)
        {
            int newValue = currencySharedModel.MoneyValue;

            newValue += _autoClickerModel.IncomePerSecond;

            currencySharedModel.SetNewCurrencyValue(newValue);
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
