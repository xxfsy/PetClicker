public class ClickPresenter : BasePresenter, IClickablePresenter
{
    // TODO: ��������� ������ ��� handleClick-�, �� ���-�� ��� ���� ������� ���������� ����� ��� MVP �� ���-�� ��� ��������� ����� ����� ������� ������

    private IClickableModel _clickableModel => _model as IClickableModel;

    public ClickPresenter(BaseModel model) : base(model)
    {

    }

    public void HandleClick()
    {
        throw new System.NotImplementedException();
    }
}
