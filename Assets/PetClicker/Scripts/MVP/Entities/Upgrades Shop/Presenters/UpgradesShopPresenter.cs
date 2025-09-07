using System;

public class UpgradesShopPresenter : BaseUpgradesShopPresenter, IUseEventBus 
{
    private BaseEventBus _eventBus;

    public void SetEventBus(BaseEventBus eventBus)
    {
        _eventBus = eventBus;
    }

    public override void HandleViewInput(BaseUpgradeItem upgradeItemConfig)
    {
        UpdateModelAfterViewInput(upgradeItemConfig);
    }

    protected override void UpdateModelAfterViewInput(BaseUpgradeItem upgradeItem)
    {
        //if (currencySharedModel == null)
        //    return;

        int currencyAmount = currencySharedModel.CurrentAmount;

        if (currencyAmount >= upgradeItem.Price)
        {
            int newPurchasedCount = upgradesShopModel.UpgradesPurchasedCount[upgradeItem];

            newPurchasedCount++; 

            upgradesShopModel.SetNewPurchasedCount(upgradeItem, newPurchasedCount);

            currencyAmount -= upgradeItem.Price; // мб вынести в отдельный метод изменений шаред модели

            currencySharedModel.SetNewCurrencyAmount(currencyAmount);

            switch (upgradeItem) // Можно наверное переделать потом на паттерн Визитер
            {
                case AutoClickerUpgradeItem autoClickerUpgradeItem:
                    _eventBus.Invoke(new AutoClickerUpgradeBoughtSignal(autoClickerUpgradeItem.UpgradeValue));
                    break;

                case ClickerUpgradeItem clickerUpgradeItem:
                    _eventBus.Invoke(new ClickerUpgradeBoughtSignal(clickerUpgradeItem.UpgradeValue));
                    break;

                default:
                    throw new ArgumentException(nameof(upgradeItem));
            }
        }
        else
        {
            return;
        }
    }
}
