using UnityEngine.Events;

public abstract class BaseUpgradeItemView : BaseView
{
    public abstract void InitializeUpgradeItemView(BaseUpgradeItem upgradeItemConfig, UnityAction<BaseUpgradeItem> actionAfterClick);

    protected abstract void OnUpgradeItemInteracted();

    public abstract void SetLocked(bool isLocked);
}
// ???? Метод реакции на кнопку, как в кликере; Метод отрисовки заблокированной версии айтема с параметром бул, если тру то заблокирован если фолс то разблокирован (мб так сделать не знаю)