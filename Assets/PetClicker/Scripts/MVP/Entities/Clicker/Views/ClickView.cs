using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ClickView : BaseView, IClickableView, IUsingSharedModelView
{
    private IClickablePresenter _clickablePresenter => presenter as IClickablePresenter;

    [SerializeField] private TextMeshProUGUI _textForClickData;
    [SerializeField] private TextMeshProUGUI _moneyText;

    [SerializeField] private Button _clickerButton;

    private void OnEnable()
    {
        _clickerButton.onClick.AddListener(OnClickerClicked);
    }

    private void OnDisable()
    {
        _clickerButton.onClick.RemoveListener(OnClickerClicked);
    }

    public void OnClickerClicked()
    {
        _clickablePresenter?.HandleClick();
    }

    public void DisplayNewDataFromModel(string newValue)
    {
        _textForClickData.SetText(newValue);
    }

    public void DisplayNewDataFromSharedModel(string newValue)
    {
        _moneyText.SetText(newValue);
    }
}
