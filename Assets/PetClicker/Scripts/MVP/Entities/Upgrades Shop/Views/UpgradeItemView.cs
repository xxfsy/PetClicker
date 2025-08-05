using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UpgradeItemView : BaseView, IUpgradeItemView
{
    private BaseUpgradeItem _upgradeItemConfig;

    [SerializeField] private Sprite _icon;
    [SerializeField] private int _price;
    [SerializeField] private float _upgradeValue;

    [SerializeField] private Button _upgradeItemButton;
    private UnityAction<BaseUpgradeItem> _actionAfterClick;

    [SerializeField] private Text _boughtCountText;

    private void OnEnable()
    {
        _upgradeItemButton.onClick.AddListener(OnUpgradeItemClicked);
    }

    private void OnDisable()
    {
        _upgradeItemButton.onClick.RemoveListener(OnUpgradeItemClicked);
    }

    public override void DisplayNewDataFromModel(string newValue)
    {
        throw new System.NotImplementedException();
    }

    public void InitializeUpgradeItemView(BaseUpgradeItem upgradeItemConfig, UnityAction<BaseUpgradeItem> actionAfterClick)
    {
        _upgradeItemConfig = upgradeItemConfig;

        _icon = _upgradeItemConfig.Icon;
        _price = _upgradeItemConfig.Price;
        _upgradeValue = _upgradeItemConfig.UpgradeValue;

        _actionAfterClick = actionAfterClick;

        //switch (upgradeItemConfig)
        //{
        //    case AutoClickerUpgradeItem autoClickerUpgradeItem:
        //        break;

        //    case ClickerUpgradeItem clickerUpgradeItem:
        //        break;

        //    default:
        //        throw new ArgumentException(nameof(upgradeItemConfig));
        //}
    }

    public void OnUpgradeItemClicked()
    {
        _actionAfterClick?.Invoke(_upgradeItemConfig);
    }

    protected void SetLocked(bool isLocked)
    {
        throw new System.NotImplementedException();
    }

    void IUpgradeItemView.SetLocked(bool isLocked)
    {
        throw new System.NotImplementedException();
    }
}
