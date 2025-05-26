using UnityEngine;

public abstract class BaseView : MonoBehaviour, IControllable // �� ������� ��� �������� ������� ���� ��� ����� �������� � UI unity?
{
    protected BasePresenter _presenter;

    public void Initialize(BasePresenter presenter)
    {
        _presenter = presenter;
    }
}
