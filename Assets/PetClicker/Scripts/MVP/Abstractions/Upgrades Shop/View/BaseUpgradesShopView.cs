public abstract class BaseUpgradesShopView : BaseView
{
    protected BaseUpgradesShopPresenter upgradesShopPresenter => presenter as BaseUpgradesShopPresenter; 

    protected BaseShopContent shopContentConfig; 

    public abstract void InitializeUpgradesShopView(BaseShopContent shopContentConfig);

    protected abstract void InitializeShopContent();

    protected abstract void HandleOnUpgradeItemViewInput(BaseUpgradeItem upgradeItemConfig);

    public abstract void HandleDisplayNewUpgradeItemDataFromModel(BaseUpgradeItem upgradeItem, int newPurchasedCount); 
}
