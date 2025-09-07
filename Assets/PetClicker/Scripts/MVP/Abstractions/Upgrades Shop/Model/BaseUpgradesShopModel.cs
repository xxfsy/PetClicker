using System.Collections.Generic;

public abstract class BaseUpgradesShopModel : BaseSaveableModel
{
    protected BaseUpgradesShopView upgradesShopView => view as BaseUpgradesShopView; // мб еще так что-то вынести из реализаций как вот ссылка на слой после каста. 

    protected BaseShopContent shopContentConfig; // эксперемент, надо ли выносить сюда поле или оставить в реализациях как например в автокликерПрезентере сделано с _moneySharedModel

    //protected Dictionary<AutoClickerUpgrades, int> autoClickerUpgradesPurchasedCount;

    //protected Dictionary<ClickerUpgrades, int> clickerUpgradesPurchasedCount;

    //public IReadOnlyDictionary<AutoClickerUpgrades, int> AutoClickerUpgradesPurchasedCount => autoClickerUpgradesPurchasedCount;

    //public IReadOnlyDictionary<ClickerUpgrades, int> ClickerUpgradesPurchasedCount => clickerUpgradesPurchasedCount;

    // кол-во купленных апгрейдов, в ключе хранится ссылка на СО. Нужен метод инициализации походу чтобы прокидывать шопКонтент и инициализировать словарь, как во вьюшке. Может можно тогда это сделать через контроллер, в контроллер будет прокидываться шоп контент, а он уже будет инициализировать шоп вью и шоп модель через каст, как в других контроллерах
    protected Dictionary<BaseUpgradeItem, int> upgradesPurchasedCount = new Dictionary<BaseUpgradeItem, int>(); // при сохранении просто будем кастить в нужный тип и сохранять в нужный список в гейм дате, ведь енамы не могут повторяться и это не ссылочный тип. значит в геймдате будут храниться просто кол-во купленных айдишников и все норм короче по идее будет

    public IReadOnlyDictionary<BaseUpgradeItem, int> UpgradesPurchasedCount => upgradesPurchasedCount;

    public abstract void InitializeUpgradesShopModel(BaseShopContent shopContentConfig);

    public abstract void SetNewPurchasedCount(BaseUpgradeItem upgradeConfig, int newPurchasedCount);
}
