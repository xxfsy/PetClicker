public class ClickerUpgradeBoughtSignal : BaseSignal
{
    public readonly int UpgradeValue;

    public ClickerUpgradeBoughtSignal(int upgradeValue)
    {
        UpgradeValue = upgradeValue;
    }
}
