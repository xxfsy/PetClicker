using System.Collections.Generic;

public class UpgradesShopView : BaseView, IUpgradesShopView
{
    private BaseShopContent _shopContentConfig;
    private BaseView _upgradeItemViewPrefab; 

    private List<BaseView> _upgradeItemViews;

    public override void DisplayNewDataFromModel(string newValue)
    {
        throw new System.NotImplementedException();
    }

    public void Initialize(BaseShopContent shopContentConfig, BaseView upgradeItemViewPrefab)
    {
        _shopContentConfig = shopContentConfig;
        _upgradeItemViewPrefab = upgradeItemViewPrefab;

        //UpgradeItemView test = new UpgradeItemView();
        //test.InitializeUpgradeItemView((_shopContentConfig as UpgradesShopContent).AutoClickerUpgradeItems.GetEnumerator().Current, OnUpgradeItemClicked);

        InitializeShopContent();
    }

    private void InitializeShopContent()
    {

    }

    private void OnUpgradeItemClicked(BaseUpgradeItem upgradeItemConfig)
    {

    }
}
