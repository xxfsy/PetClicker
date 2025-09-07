using System.Collections.Generic;
using UnityEngine;

public class UpgradesShopView : BaseUpgradesShopView
{
    [SerializeField] private BaseUpgradeItemView _upgradeItemViewPrefab; //надо ли это выносить в абстрактный класс (?) 

    [SerializeField] private GameObject _gameObjectForUpgradeItemViews; //надо ли это выносить в абстрактный класс (?)

    private Dictionary<BaseUpgradeItem, BaseUpgradeItemView> _upgradeItemsViews = new(); 

    public override void InitializeUpgradesShopView(BaseShopContent shopContentConfig)
    {
        this.shopContentConfig = shopContentConfig;

        InitializeShopContent();
    }

    public override void HandleDisplayNewUpgradeItemDataFromModel(BaseUpgradeItem upgradeItem, int newPurchasedCount) 
    {
        _upgradeItemsViews[upgradeItem].DisplayNewUpgradeItemDataFromModel(newPurchasedCount);
    }

    protected override void InitializeShopContent()
    {
        foreach (BaseUpgradeItem upgradeItem in shopContentConfig.AutoClickerAndClickerUpgradeItems)
        {
            BaseUpgradeItemView upgradeItemView = Instantiate(_upgradeItemViewPrefab, _gameObjectForUpgradeItemViews.transform);

            upgradeItemView.InitializeUpgradeItemView(upgradeItem, HandleOnUpgradeItemViewInput);
            _upgradeItemsViews.Add(upgradeItem, upgradeItemView);
        }
    }

    protected override void HandleOnUpgradeItemViewInput(BaseUpgradeItem upgradeItemConfig) // вызывается через делегат в апгрейд айтеме. Дергаем презентер тут
    {
        upgradesShopPresenter.HandleViewInput(upgradeItemConfig);
    }
}
