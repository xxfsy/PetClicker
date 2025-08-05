using UnityEngine.Events;

public interface IUpgradeItemView
{
    public void InitializeUpgradeItemView(BaseUpgradeItem upgradeItemConfig, UnityAction<BaseUpgradeItem> actionAfterClick);

    public void OnUpgradeItemClicked();

    public void SetLocked(bool isLocked);
}
// ???? Метод реакции на кнопку, как в кликере; Метод отрисовки заблокированной версии айтема с параметром бул, если тру то заблокирован если фолс то разблокирован (мб так сделать не знаю)