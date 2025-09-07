
public class AutoClickerPresenter : BaseAutoClickerPresenter, IUseEventBus 
{
    public override float TickCooldownInSeconds { get; protected set; }

    private BaseEventBus _eventBus;

    public override void SetTickCooldown(float tickCooldownInSeconds)
    {
        TickCooldownInSeconds = tickCooldownInSeconds;
    }

    public void SetEventBus(BaseEventBus eventBus)
    {
        _eventBus = eventBus;
        Subscribe();
    }

    public override void Tick()
    {
        UpdateSharedModel();
    }

    protected override void UpdateSharedModel()
    {
        //if (currencySharedModel == null)
        //    return;

        float newValue = currencySharedModel.GetCurrentAmountOfCurrency();

        newValue += autoClickerModel.IncomePerSecond;

        currencySharedModel.SetNewCurrencyAmount(newValue);
    }

    private void OnAutoClickerUpgradeBought(AutoClickerUpgradeBoughtSignal autoClickerUpgradeBoughtSignal)
    {
        int upgradeValue = autoClickerUpgradeBoughtSignal.UpgradeValue;

        int currentIncomePerSecond = autoClickerModel.IncomePerSecond;
        autoClickerModel.SetNewValueForIncomePerSecond(currentIncomePerSecond + upgradeValue);
    }

    private void Subscribe()
    {
        _eventBus.Subscribe<AutoClickerUpgradeBoughtSignal>(OnAutoClickerUpgradeBought);
    }

    private void UnSubscribe()
    {

    }

}
