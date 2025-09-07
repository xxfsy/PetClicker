using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "UpgradesShopContent", menuName = "ScriptableObject/UpgradesShop/Contents/UpgradesShopContent")]
public class UpgradesShopContent : BaseShopContent
{
    private void OnValidate() 
    {
        HashSet<ClickerUpgrades> seenClickerIds = new HashSet<ClickerUpgrades>();
        HashSet<AutoClickerUpgrades> seenAutoClickerIds = new HashSet<AutoClickerUpgrades>();

        foreach (BaseUpgradeItem item in AutoClickerAndClickerUpgradeItems)
        {
            switch (item) // Можно переделать потом на паттерн Визитер
            {
                case AutoClickerUpgradeItem autoClickerUpgradeItem:
                    if (!seenAutoClickerIds.Add(autoClickerUpgradeItem.AutoClickerUpgradeType))
                    {
                        Debug.LogError($"Duplicate AutoClickerUpgradeType detected: {autoClickerUpgradeItem.AutoClickerUpgradeType} in {this.name}", this);
                    }
                    break;

                case ClickerUpgradeItem clickerUpgradeItem:
                    if (!seenClickerIds.Add(clickerUpgradeItem.ClickerUpgradeType))
                    {
                        Debug.LogError($"Duplicate ClickerUpgradeType detected: {clickerUpgradeItem.ClickerUpgradeType} in {this.name}", this);
                    }
                    break;

                default:
                    throw new ArgumentException(nameof(item));
            }
        }
    }
}
