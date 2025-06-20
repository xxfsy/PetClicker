using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ClickerView : BaseView, IClickerView, IUsingSharedModelView
{
    private IClickerPresenter _clickerPresenter => presenter as IClickerPresenter;

    [SerializeField] private TextMeshProUGUI _textForClickData;
    [SerializeField] private TextMeshProUGUI _moneyText; // вынести в отдельную вьюшку

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
        _clickerPresenter?.HandleClick();
    }

    public void DisplayNewDataFromModel(string newValue)
    {
        _textForClickData.SetText(newValue);
    }

    public void DisplayNewDataFromSharedModel(string newValue) // вынести в отдельную вьюшку
    {
        _moneyText.SetText(newValue);
    }
}
