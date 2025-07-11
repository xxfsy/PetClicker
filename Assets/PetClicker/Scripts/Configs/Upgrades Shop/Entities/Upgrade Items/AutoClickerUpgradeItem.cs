using UnityEngine;

[CreateAssetMenu(fileName = "AutoClickerUpgradeItem", menuName = "ScriptableObject/UpgradesShop/Items/AutoClickerUpgradeItem")]
public class AutoClickerUpgradeItem : BaseUpgradeItem
{
    [field: SerializeField] public AutoClickerUpgrades AutoClickerUpgradeType { get; private set; }
}
