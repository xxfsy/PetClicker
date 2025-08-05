using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ClickerView : BaseClickerView
{
    private BaseClickerPresenter _clickerPresenter => presenter as BaseClickerPresenter;

    [SerializeField] private TextMeshProUGUI _clicksCountText;

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

    public override void DisplayNewDataFromModel(string newValue)
    {
        _clicksCountText.SetText(newValue);
    }
}
