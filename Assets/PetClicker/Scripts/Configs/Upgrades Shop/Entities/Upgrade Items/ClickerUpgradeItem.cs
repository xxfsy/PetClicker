using UnityEngine;

[CreateAssetMenu(fileName = "ClickerUpgradeItem", menuName = "ScriptableObject/UpgradesShop/Items/ClickerUpgradeItem")]
public class ClickerUpgradeItem : BaseUpgradeItem
{
    [field: SerializeField] public ClickerUpgrades ClickerUpgradeType { get; private set; }
}
