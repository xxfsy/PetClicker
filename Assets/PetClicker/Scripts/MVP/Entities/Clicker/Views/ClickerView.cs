using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ClickerView : BaseClickerView
{
    private BaseClickerPresenter _clickerPresenter => presenter as BaseClickerPresenter;

    [SerializeField] private TextMeshProUGUI _clicksCountText;
    [SerializeField] private TextMeshProUGUI _incomePerClickText;

    [SerializeField] private string _prefixForIncomePerClick = "/click";

    [SerializeField] private Button _clickerButton;

    private void OnEnable()
    {
        _clickerButton.onClick.AddListener(OnClickerClicked);
    }

    private void OnDisable()
    {
        _clickerButton.onClick.RemoveListener(OnClickerClicked);
    }

    protected override void OnClickerClicked()
    {
        _clickerPresenter?.HandleClick();
    }

    public override void DisplayNewClicksCountFromModel(string newValue)
    {
        _clicksCountText.SetText(newValue);
    }

    public override void DisplayNewIncomePerClickFromModel(string newValue)
    {
        _incomePerClickText.SetText(newValue + _prefixForIncomePerClick);
    }
}
