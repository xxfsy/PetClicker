using System;

public class AutoClickerPresenter : BasePresenter, IUsingSharedModelPresenter, ITickable
{
    private IAutoClickerModel _autoClickerModel => model as IAutoClickerModel;

    private BaseSharedModel _moneySharedModel;

    public float TickCooldownInSeconds { get; private set; } = 1f; // подумать как прокинуть сюда значение 

    private float _timerToCooldownTick;

    public void SetSharedModel(BaseSharedModel sharedModel)
    {
        _moneySharedModel = sharedModel;
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
            throw new NullReferenceException("SharedModel is not ICurrencySharedModel");
            //return;
        }
    }

    public void Tick(float timeFromLastTick)
    {
        _timerToCooldownTick += timeFromLastTick;

        if (_timerToCooldownTick >= TickCooldownInSeconds)
        {
            _timerToCooldownTick = 0;
            UpdateSharedModel();
        }
    }

}
