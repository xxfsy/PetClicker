
// от IUseEventBas я думаю наследоваться надо тут а не в BaseUpgradesShopPresenter, так как это часть реализации, мы можем писать разные презенторы для UpgradesShop кто-то может использовать eventBus, кто-то нет, в этом и прикол
using System;

public class UpgradesShopPresenter : BaseUpgradesShopPresenter, IUseEventBus 
{
    // возможная бизнес логика: проверка баланса, хватает ли на покупку; Мб сделать какой-нибудь UpgradeService

    //поле которое прибавляется при покупке (+1 к купленным типа), сделать поле чтобы можно было в случае чего какие-то бафы может накидывать x2 там типа и тд, надо подумать как его сюда прокинуть

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

        float currentMoneyAmount = currencySharedModel.GetCurrentAmountOfCurrency();

        if (currentMoneyAmount >= upgradeItem.Price)
        {
            int newPurchasedCount = upgradesShopModel.UpgradesPurchasedCount[upgradeItem];

            newPurchasedCount++; // временно так

            upgradesShopModel.SetNewPurchasedCount(upgradeItem, newPurchasedCount);

            currentMoneyAmount -= upgradeItem.Price; // мб вынести в отдельный метод изменений шаред модели

            currencySharedModel.SetNewCurrencyAmount(currentMoneyAmount);

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
