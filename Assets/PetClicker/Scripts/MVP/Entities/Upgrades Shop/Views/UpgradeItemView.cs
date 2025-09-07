using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UpgradeItemView : BaseUpgradeItemView
{
    private BaseUpgradeItem _upgradeItemConfig;

    //подумать, может что-то из нижеперечисленных полей можно вынести в базовый класс
    private int _purchasedCount; // кол-во купленных улучшений

    [SerializeField] TextMeshProUGUI _upgradeNameText;
    [SerializeField] Image _iconImage;
    [SerializeField] TextMeshProUGUI _priceText;
    [SerializeField] TextMeshProUGUI _upgradeValueText;

    [SerializeField] private TextMeshProUGUI _purchasedCountText;

    [SerializeField] private string _prefixForPrice = "$";
    [SerializeField] private string _prefixForUpgradeValue = "+";

    [SerializeField] private string _prefixForPurchasedCount = "Bought";

    [SerializeField] private Button _upgradeItemBuyButton;
    private UnityAction<BaseUpgradeItem> _actionAfterClick;

    public bool IsLocked { get; private set; } = false;

    private void OnEnable()
    {
        _upgradeItemBuyButton.onClick.AddListener(OnInput);
    }

    private void OnDisable()
    {
        _upgradeItemBuyButton.onClick.RemoveListener(OnInput);
    }

    public override void InitializeUpgradeItemView(BaseUpgradeItem upgradeItemConfig, UnityAction<BaseUpgradeItem> actionAfterClick)
    {
        _upgradeItemConfig = upgradeItemConfig;

        _actionAfterClick = actionAfterClick;

        DisplayInitializedData();
    }

    public override void DisplayNewUpgradeItemDataFromModel(int newPurchasedCount) 
    {
        _purchasedCount = newPurchasedCount;

        _purchasedCountText.SetText(_purchasedCount.ToString() + " " + _prefixForPurchasedCount);
    }

    public override void SetLocked(bool isLocked)
    {
        IsLocked = isLocked;

        _upgradeItemBuyButton.gameObject.SetActive(!isLocked);

        // добавить логику блокирования, либо какую-то картинку то что заблокировано либо  укаждого апгрейда будет в себе храниться еще иконка для заблокированного состояния и ставить эту иконку в имедж и например просто текст пустым делать для цены и остального

        throw new System.NotImplementedException();
    }

    protected override void OnInput()
    {
        _actionAfterClick?.Invoke(_upgradeItemConfig);
    }

    protected override void DisplayInitializedData()
    {
        _upgradeNameText.SetText(_upgradeItemConfig.UpgradeName);
        _iconImage.sprite = _upgradeItemConfig.Icon;
        _priceText.SetText(_upgradeItemConfig.Price.ToString() + " " + _prefixForPrice);
        _upgradeValueText.SetText(_prefixForUpgradeValue + _upgradeItemConfig.UpgradeValue.ToString());
    }
}
