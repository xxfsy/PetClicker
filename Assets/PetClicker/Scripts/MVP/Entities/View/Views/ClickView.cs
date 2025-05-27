using TMPro;
using UnityEngine;

public class ClickView : BaseView, IClickableView
{
    // TODO: ������� �����-�� ������ ��� �������� ��� ��������� ����� �������� ���� ������� ����� �������� ui. ���� �� ������� ������ ����, ���� ��� �� ��������������� ������, ������ ����� ������
    // ������ ������, ��� ������ �������� ��������, � ������ ���� ������ ��� ������ �� ���������. ����� ��, ��� ����, �������� ������. ����� �������� ���������� ������

    private IClickablePresenter _clickablePresenter => _presenter as IClickablePresenter;

    [SerializeField] private TextMeshPro _moneyText;

    public void OnClickerClicked()
    {
        _clickablePresenter?.HandleClick();
    }

    public void UpdateUIAfterClick(string newValue)
    {
        throw new System.NotImplementedException();
    }
}
