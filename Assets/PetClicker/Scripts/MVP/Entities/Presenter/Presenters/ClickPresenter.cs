public class ClickPresenter : BasePresenter, IClickablePresenter
{
    // TODO: ��������� ������ ��� handleClick-�, �� ���-�� ��� ���� ������� ���������� ����� ��� MVP �� ���-�� ��� ��������� ����� ����� ������� ������
    // �.�. Presenter ������������ ����� � ���� � �������� ������, �� ������ ���������� ����� ������ ������ ���, � ������ ������ ������ ��������, � �� ��������� � ���� ������ ��������� �����

    private IClickableModel _clickableModel => _model as IClickableModel;

    public ClickPresenter(BaseModel model) : base(model)
    {

    }

    public void HandleClick()
    {
        UpdateMoneyValue();
    }

    public void UpdateMoneyValue()
    {
        throw new System.NotImplementedException();
    }
}
