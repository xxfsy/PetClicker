using System;
using System.Collections.Generic;
using System.Linq;

public class UpgradesShopModel : BaseUpgradesShopModel
{
    public override void InitializeUpgradesShopModel(BaseShopContent shopContentConfig)
    {
        this.shopContentConfig = shopContentConfig;

        foreach (BaseUpgradeItem upgradeItem in this.shopContentConfig.AutoClickerAndClickerUpgradeItems)
        {
            upgradesPurchasedCount.Add(upgradeItem, default);
        }
    }

    public override void SaveLayer(BaseData baseData)
    {
        if (baseData is GameData gameData)
        {
            foreach (KeyValuePair<BaseUpgradeItem, int> upgrade in upgradesPurchasedCount)
            {
                switch (upgrade.Key) // Можно переделать потом на паттерн Визитер
                {
                    case AutoClickerUpgradeItem autoClickerUpgradeItem: // без проверки на переписывание того же значение чтобы если словарь пустой записать новое значение а не упасть в нулл референс
                        gameData.AutoClickerUpgradesPurchasedCount[autoClickerUpgradeItem.AutoClickerUpgradeType] = upgradesPurchasedCount[autoClickerUpgradeItem];
                        break;

                    case ClickerUpgradeItem clickerUpgradeItem: // без проверки на переписывание того же значение чтобы если словарь пустой записать новое значение а не упасть в нулл референс
                        gameData.ClickerUpgradesPurchasedCount[clickerUpgradeItem.ClickerUpgradeType] = upgradesPurchasedCount[clickerUpgradeItem];
                        break;

                    default:
                        throw new ArgumentException(nameof(upgrade.Key));
                }
            }
        }
        else
        {
            return;
        }
    }

    public override void LoadLayer(BaseData baseData)
    {
        if (baseData is GameData gameData)
        {
            foreach (BaseUpgradeItem upgradesPurchasedCountKey in upgradesPurchasedCount.Keys.ToList())
            {
                switch (upgradesPurchasedCountKey) // Можно переделать потом на паттерн Визитер
                {
                    case AutoClickerUpgradeItem autoClickerUpgradeItem:
                        if (gameData.AutoClickerUpgradesPurchasedCount.TryGetValue(autoClickerUpgradeItem.AutoClickerUpgradeType, out int autoClickerValue))
                            upgradesPurchasedCount[autoClickerUpgradeItem] = autoClickerValue;
                        break;

                    case ClickerUpgradeItem clickerUpgradeItem:
                        if (gameData.ClickerUpgradesPurchasedCount.TryGetValue(clickerUpgradeItem.ClickerUpgradeType, out int clickerValue))
                            upgradesPurchasedCount[clickerUpgradeItem] = clickerValue;
                        break;

                    default:
                        throw new ArgumentException(nameof(upgradesPurchasedCountKey));

                }

                upgradesShopView.HandleDisplayNewUpgradeItemDataFromModel(upgradesPurchasedCountKey, upgradesPurchasedCount[upgradesPurchasedCountKey]);
            }
        }
        else
        {
            return;
        }
    }

    public override void SetNewPurchasedCount(BaseUpgradeItem upgradeConfig, int newPurchasedCount)
    {
        upgradesPurchasedCount[upgradeConfig] = newPurchasedCount;

        upgradesShopView.HandleDisplayNewUpgradeItemDataFromModel(upgradeConfig, newPurchasedCount);
    }
}
