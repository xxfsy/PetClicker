public class ClickPresenter : BasePresenter, IClickablePresenter, IUsingSharedModelLayer
{
    // �.�. Presenter ������������ ����� � ���� � �������� ������, �� ������ ���������� ����� ������ ������ ���, � ������ ������ ������ ��������, � �� ��������� � ���� ������ ��������� �����

    private IClickableModel _clickableModel => model as IClickableModel;

    private BaseSharedModel _moneySharedModel;

    public void SetSharedModel(BaseSharedModel sharedModel)
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

    private void UpdateSharedModelAfterClick()
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
