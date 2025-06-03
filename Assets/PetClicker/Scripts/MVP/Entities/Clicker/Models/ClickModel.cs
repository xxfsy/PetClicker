public class ClickModel : BaseModel, IClickableModel
{
    // TODO: �������� ������, �������� ui ����� ���������� ����� - ���� � UpdateMoneyData ���� � ��������� ������ (��������)

    private IClickableView _clickableView => view as IClickableView;

    public int ClicksValue { get; private set; }

    public void SetNewValueAfterClick(int newValue)
    {
        ClicksValue = newValue;

        _clickableView?.DisplayClickResult(newValue.ToString());
    }
}
