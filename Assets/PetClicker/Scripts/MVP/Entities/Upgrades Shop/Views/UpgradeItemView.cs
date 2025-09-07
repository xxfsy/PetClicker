using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UpgradeItemView : BaseUpgradeItemView
{
    private BaseUpgradeItem _upgradeItemConfig;

    // надо ли это все снизу вынести в базовый класс?
    private string _upgradeName;
    private Sprite _icon;
    private int _price;
    private float _upgradeValue;

    private int _purchasedCount; // кол-во купленных улучшений

    [SerializeField] TextMeshProUGUI _upgradeNameText;
    [SerializeField] Image _iconImage;
    [SerializeField] TextMeshProUGUI _priceText;
    [SerializeField] TextMeshProUGUI _upgradeValueText;

    [SerializeField] private TextMeshProUGUI _purchasedCountText;

    [SerializeField] private Button _upgradeItemBuyButton;
    private UnityAction<BaseUpgradeItem> _actionAfterClick;

    public bool IsLocked { get; private set; } = false;
    // надо ли это все сверху вынести в базовый класс?

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

        _upgradeName = _upgradeItemConfig.UpgradeName;
        _icon = _upgradeItemConfig.Icon;
        _price = _upgradeItemConfig.Price;
        _upgradeValue = _upgradeItemConfig.UpgradeValue;

        _actionAfterClick = actionAfterClick;

        DisplayInitializedData();
    }

    public override void DisplayNewUpgradeItemDataFromModel(int newPurchasedCount) // Параметры: новое кол-во купленных апгрейдов данной вьюшки
    {
        _purchasedCount = newPurchasedCount;

        _purchasedCountText.SetText(_purchasedCount.ToString());
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
        _upgradeNameText.SetText(_upgradeName);
        _iconImage.sprite = _icon;
        _priceText.SetText(_price.ToString());
        _upgradeValueText.SetText(_upgradeValue.ToString());
    }
}
