public class ClickPresenter : BasePresenter, IClickablePresenter, IUsingSharedModel
{
    // TODO: ��������� ������ ��� handleClick-�, �� ���-�� ��� ���� ������� ���������� ����� ��� MVP �� ���-�� ��� ��������� ����� ����� ������� ������
    // �.�. Presenter ������������ ����� � ���� � �������� ������, �� ������ ���������� ����� ������ ������ ���, � ������ ������ ������ ��������, � �� ��������� � ���� ������ ��������� �����

    private IClickableModel _clickableModel => _model as IClickableModel;

    private SharedModel _moneySharedModel;

    public ClickPresenter(BaseModel model) : base(model)
    {

    }

    public void SetSharedModel(SharedModel sharedModel)
    {
        _moneySharedModel = sharedModel;
    }

    public void HandleClick()
    {
        UpdateModelAfterClick();
        UpdateSharedModelAfterClick();
    }

    public void UpdateModelAfterClick()
    {
        int newValue = _clickableModel.ClicksValue;

        newValue++;

        _clickableModel?.SetNewValueAfterClick(newValue);
    }

    public void UpdateSharedModelAfterClick()
    {
        if (_moneySharedModel is ICurrencySharedModel currencySharedModel)
        {
            int newValue = currencySharedModel.MoneyValue;

            newValue++;

            currencySharedModel.SetNewMoneyValue(newValue);
        }
        else
        {
            return;
        }
    }
}
