public abstract class BaseUpgradesShopPresenter : BaseUsingCurrencySharedModelPresenter 
{
    protected BaseUpgradesShopModel upgradesShopModel => model as BaseUpgradesShopModel; 

    public abstract void HandleViewInput(BaseUpgradeItem upgradeItem); 

    protected abstract void UpdateModelAfterViewInput(BaseUpgradeItem upgradeItem);
}
