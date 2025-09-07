using UnityEngine.Events;

public abstract class BaseUpgradeItemView : BaseView // сделать BaseView без презентера и унаследоваться от него, ведь тут презентер не нужен
{
    public abstract void InitializeUpgradeItemView(BaseUpgradeItem upgradeItemConfig, UnityAction<BaseUpgradeItem> actionAfterClick);

    public abstract void SetLocked(bool isLocked);

    public abstract void DisplayNewUpgradeItemDataFromModel(int newPurchasedCount);

    protected abstract void OnInput();

    protected abstract void DisplayInitializedData();
}
// ???? Метод реакции на кнопку, как в кликере; Метод отрисовки заблокированной версии айтема с параметром бул, если тру то заблокирован если фолс то разблокирован (мб так сделать не знаю)