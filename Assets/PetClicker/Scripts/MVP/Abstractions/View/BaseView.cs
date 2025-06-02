using UnityEngine;

public abstract class BaseView : MonoBehaviour // �� ������� ��� �������� ������� ���� ��� ����� �������� � UI unity?
{
    protected BasePresenter _presenter;

    public void Initialize(BasePresenter presenter)
    {
        _presenter = presenter;
    }
}
