using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ClickerView : BaseView, IClickerView
{
    private IClickerPresenter _clickerPresenter => presenter as IClickerPresenter;

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

    public void OnClickerClicked()
    {
        _clickerPresenter?.HandleClick();
    }

    public override void DisplayNewDataFromModel(string newValue)
    {
        _clicksCountText.SetText(newValue);
    }
}
