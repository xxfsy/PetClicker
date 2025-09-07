public abstract class BaseUpgradesShopView : BaseView
{
    protected BaseUpgradesShopPresenter upgradesShopPresenter => presenter as BaseUpgradesShopPresenter; // сделать ли так во всех базовых слоях конкретного трио (?)

    protected BaseShopContent shopContentConfig; // эксперемент, надо ли выносить сюда поле или оставить в реализациях как например в автокликерПрезентере сделано с _moneySharedModel. спросить у чата

    public abstract void InitializeUpgradesShopView(BaseShopContent shopContentConfig);

    protected abstract void InitializeShopContent();

    protected abstract void HandleOnUpgradeItemViewInput(BaseUpgradeItem upgradeItemConfig);

    public abstract void HandleDisplayNewUpgradeItemDataFromModel(BaseUpgradeItem upgradeItem, int newPurchasedCount); // параметры id и новое купленное кол-во.
}
// TODO: подумать какие добавить новые методы. Мб уже не надо
