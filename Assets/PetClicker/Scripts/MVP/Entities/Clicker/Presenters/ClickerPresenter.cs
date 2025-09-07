
public class ClickerPresenter : BaseClickerPresenter, IUseEventBus 
{
    // т.к. Presenter обрабатывает клики с вида и изменяет модель, то логика обновления денег должна лежать тут (бизнес-логика), а модель должна просто меняться, а не содержать в себе логику изменения денег

    private BaseEventBus _eventBus;

    public void SetEventBus(BaseEventBus eventBus)
    {
        _eventBus = eventBus;
        Subscribe();
    }

    public override void HandleClick()
    {
        UpdateModelsAfterClick();
    }

    protected override void UpdateModelsAfterClick()
    {
        int currentClicksCount = clickerModel.ClicksCount;

        currentClicksCount++;

        clickerModel.SetNewClicksCountValue(currentClicksCount);

        // мб вынести в отдельный метод изменений шаред модели
        int currencyAmount = currencySharedModel.CurrentAmount; 
        currencyAmount += clickerModel.IncomePerClick;
        currencySharedModel.SetNewCurrencyAmount(currencyAmount);
    }

    private void OnClickerUpgradeBought(ClickerUpgradeBoughtSignal autoClickerUpgradeBoughtSignal)
    {
        int upgradeValue = autoClickerUpgradeBoughtSignal.UpgradeValue;

        int currentIncomePerSecond = clickerModel.IncomePerClick;
        clickerModel.SetNewValueForIncomePerClick(currentIncomePerSecond + upgradeValue);
    }

    private void Subscribe()
    {
        _eventBus.Subscribe<ClickerUpgradeBoughtSignal>(OnClickerUpgradeBought);
    }

    private void UnSubscribe()
    {
        _eventBus.Unsubscribe<ClickerUpgradeBoughtSignal>(OnClickerUpgradeBought);
    }
}
