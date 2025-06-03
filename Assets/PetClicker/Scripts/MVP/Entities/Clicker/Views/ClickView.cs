using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ClickView : BaseView, IClickableView, IUsingSharedModel
{
    // TODO: ������� �����-�� ������ ��� �������� ��� ��������� ����� �������� ���� ������� ����� �������� ui. ���� �� ������� ������ ����, ���� ��� �� ��������������� ������, ������ ����� ������
    // ������ ������, ��� ������ �������� ��������, � ������ ���� ������ ��� ������ �� ���������. ����� ��, ��� ����, �c������ ������. ����� �������� ���������� ������

    private IClickablePresenter _clickablePresenter => _presenter as IClickablePresenter;

    private SharedModel _moneySharedModel;

    [SerializeField] private TextMeshPro _textForClickData;
    [SerializeField] private TextMeshPro _moneyText;

    [SerializeField] private Button _clickerButton;

    private void OnEnable()
    {
        _clickerButton.onClick.AddListener(OnClickerClicked);

        SubscribeToSharedModel();
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

    public void SetSharedModel(SharedModel sharedModel)
    {
        _moneySharedModel = sharedModel;
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
