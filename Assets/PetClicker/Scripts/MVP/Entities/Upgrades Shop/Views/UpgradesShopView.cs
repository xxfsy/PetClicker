using System.Collections.Generic;
using UnityEngine;

public class UpgradesShopView : BaseUpgradesShopView
{
    [SerializeField] private BaseUpgradeItemView _upgradeItemViewPrefab; //надо ли это выносить в абстрактный класс (?) 

    [SerializeField] private GameObject _gameObjectForUpgradeItemViews; //надо ли это выносить в абстрактный класс (?)

    private Dictionary<BaseUpgradeItem, BaseUpgradeItemView> _upgradeItemsViews = new(); // тут под значением должен быть BaseUpgradeItemView или BaseView (?)

    public override void InitializeUpgradesShopView(BaseShopContent shopContentConfig)
    {
        this.shopContentConfig = shopContentConfig;

        InitializeShopContent();
    }

    public override void HandleDisplayNewUpgradeItemDataFromModel(BaseUpgradeItem upgradeItem, int newPurchasedCount) // метод перерисовки конкретной вьюшки через поиск по ключус словаря через ID? Параметры: id вьюшки, новое кол-во купленных апгрейдов данной вьюшки
    {
        _upgradeItemsViews[upgradeItem].DisplayNewUpgradeItemDataFromModel(newPurchasedCount);
    }

    protected override void InitializeShopContent()
    {
        int i = 0; //временно!

        foreach (BaseUpgradeItem upgradeItem in shopContentConfig.AutoClickerAndClickerUpgradeItems)
        {
            //GameObject upgradeItemView = Instantiate(_upgradeItemViewPrefab.gameObject, _gameObjectForUpgradeItemViews.transform); // будет ли разница между _upgradeItemViewPrefab и _upgradeItemViewPrefab.gameObject; (?)

            //upgradeItemView.transform.position += new Vector3(0,100 * i,0); // Для теста так сделал, потом надо сделать просто объект который сам групирует и ничего не двигать через скрипт

            //сделал пока так ведь не двигаю трансформ и не нужен объект типа GameObject
            BaseUpgradeItemView upgradeItemView = Instantiate(_upgradeItemViewPrefab, _gameObjectForUpgradeItemViews.transform);

            upgradeItemView.InitializeUpgradeItemView(upgradeItem, HandleOnUpgradeItemViewInput);
            _upgradeItemsViews.Add(upgradeItem, upgradeItemView);

            i++;
        }
    }

    protected override void HandleOnUpgradeItemViewInput(BaseUpgradeItem upgradeItemConfig) // вызывается через делегат в апгрейд айтеме. Дергаем презентер тут
    {
        upgradesShopPresenter.HandleViewInput(upgradeItemConfig);
    }
}
