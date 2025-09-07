using System.Collections.Generic;

public abstract class BaseUpgradesShopModel : BaseSaveableModel
{
    protected BaseUpgradesShopView upgradesShopView => view as BaseUpgradesShopView;  

    protected BaseShopContent shopContentConfig; 

    protected Dictionary<BaseUpgradeItem, int> upgradesPurchasedCount = new Dictionary<BaseUpgradeItem, int>(); 

    public IReadOnlyDictionary<BaseUpgradeItem, int> UpgradesPurchasedCount => upgradesPurchasedCount;

    public abstract void InitializeUpgradesShopModel(BaseShopContent shopContentConfig);

    public abstract void SetNewPurchasedCount(BaseUpgradeItem upgradeConfig, int newPurchasedCount);
}
