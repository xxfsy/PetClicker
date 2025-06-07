using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ClickView : BaseView, IClickableView, IUsingSharedModelLayer
{
    // TODO: ������� �����-�� ������ ��� �������� ��� ��������� ����� �������� ���� ������� ����� �������� ui. ���� �� ������� ������ ����, ���� ��� �� ��������������� ������, ������ ����� ������
    // ������ ������, ��� ������ �������� ��������, � ������ ���� ������ ��� ������ �� ���������. ����� ��, ��� ����, �c������ ������. ����� �������� ���������� ������

    private IClickablePresenter _clickablePresenter => presenter as IClickablePresenter;

    private BaseSharedModel _moneySharedModel;

    [SerializeField] private TextMeshProUGUI _textForClickData;
    [SerializeField] private TextMeshProUGUI _moneyText;

    [SerializeField] private Button _clickerButton;

    private void OnEnable()
    {
        _clickerButton.onClick.AddListener(OnClickerClicked);

        if(_moneySharedModel != null) SubscribeToSharedModel();
    }

    private void OnDisable()
    {
        _clickerButton.onClick.RemoveListener(OnClickerClicked);

        UnsubscribeFromSharedModel();
    }

    public void OnClickerClicked()
    {
        _clickablePresenter?.HandleClick();
    }

    public void DisplayClickResult(string newValue)
    {
        _textForClickData.SetText(newValue);
    }

    public void SetSharedModel(BaseSharedModel sharedModel)
    {
        _moneySharedModel = sharedModel;

        SubscribeToSharedModel();
    }

    public void SubscribeToSharedModel()
    {
        _moneySharedModel.ViewsNotify += DisplayClickResultFromSharedModel;
    }

    public void UnsubscribeFromSharedModel()
    {
        _moneySharedModel.ViewsNotify -= DisplayClickResultFromSharedModel;
    }

    public void DisplayClickResultFromSharedModel(string newValue)
    {
        _moneyText.SetText(newValue);
    }
}
