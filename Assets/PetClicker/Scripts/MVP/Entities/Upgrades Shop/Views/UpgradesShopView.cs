using System.Collections.Generic;

public class UpgradesShopView : BaseView, IUpgradesShopView
{
    private BaseShopContent _shopContentConfig;
    private BaseView _upgradeItemViewPrefab; // не знаю оставить как поле и через инспектор прокидывать префаб апгрейда или через ентри поинт -> контроллер -> вьюшка магазина апгрейдов

    private List<BaseView> _upgradeItemViews;

    public override void DisplayNewDataFromModel(string newValue)
    {
        throw new System.NotImplementedException();
    }

    public void InitializeShopContent(BaseShopContent shopContentConfig, BaseView upgradeItemViewPrefab)
    {
        _shopContentConfig = shopContentConfig;
        _upgradeItemViewPrefab = upgradeItemViewPrefab;
    }
}
