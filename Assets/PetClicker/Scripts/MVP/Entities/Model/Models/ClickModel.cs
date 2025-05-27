public class ClickModel : BaseModel, IClickableModel
{
    // TODO: �������� ������, �������� ui ����� ���������� ����� - ���� � UpdateMoneyData ���� � ��������� ������ (��������)

    private IClickableView _clickableView => _view as IClickableView;

    private int _moneyCount;

    public ClickModel(BaseView view) : base(view)
    {

    }

    public void UpdateMoneyData(int newValue)
    {
        _moneyCount = newValue;
    }
}
