public abstract class BaseUpgradesShopPresenter : BaseUsingCurrencySharedModelPresenter 
{
    protected BaseUpgradesShopModel upgradesShopModel => model as BaseUpgradesShopModel; // сделать ли так во всех базовых слоях конкретного трио (?)

    public abstract void HandleViewInput(BaseUpgradeItem upgradeItem); 

    protected abstract void UpdateModelAfterViewInput(BaseUpgradeItem upgradeItem);
}
