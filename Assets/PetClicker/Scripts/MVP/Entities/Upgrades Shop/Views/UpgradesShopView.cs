using System.Collections.Generic;

public class UpgradesShopView : BaseUpgradesShopView
{
    private BaseShopContent _shopContentConfig;
    private BaseView _upgradeItemViewPrefab; 

    private List<BaseView> _upgradeItemViews;

    public override void DisplayNewDataFromModel(string newValue)
    {
        throw new System.NotImplementedException();
    }

    public override void Initialize(BaseShopContent shopContentConfig, BaseView upgradeItemViewPrefab)
    {
        _shopContentConfig = shopContentConfig;
        _upgradeItemViewPrefab = upgradeItemViewPrefab;

        //UpgradeItemView test = new UpgradeItemView();
        //test.InitializeUpgradeItemView((_shopContentConfig as UpgradesShopContent).AutoClickerUpgradeItems.GetEnumerator().Current, OnUpgradeItemClicked);

        InitializeShopContent();
    }

    protected override void InitializeShopContent()
    {
        throw new System.NotImplementedException();
    }

    private void OnUpgradeItemClicked(BaseUpgradeItem upgradeItemConfig)
    {
        throw new System.NotImplementedException();
    }
}
