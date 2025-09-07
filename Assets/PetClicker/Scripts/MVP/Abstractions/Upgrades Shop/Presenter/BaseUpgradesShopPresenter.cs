public abstract class BaseUpgradesShopPresenter : BaseUsingSharedModelPresenter 
{
    protected BaseUpgradesShopModel upgradesShopModel => model as BaseUpgradesShopModel; // сделать ли так во всех базовых слоях конкретного трио (?)

    public abstract void HandleViewInput(BaseUpgradeItem upgradeItem); // нормально или сделать параметр необязательным, наверное нормально

    protected abstract void UpdateModelAfterViewInput(BaseUpgradeItem upgradeItem);
}
