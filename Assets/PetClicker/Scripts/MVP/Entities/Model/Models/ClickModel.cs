public class ClickModel : BaseModel, IClickableModel
{
    // TODO: обновить деньги, обновить ui после обновления денег - либо в UpdateMoneyData либо в отдельном методе (спросить)

    private IClickableView _clickableView => _view as IClickableView;

    public int MoneyValue { get; private set; }

    public ClickModel(BaseView view) : base(view)
    {

    }

    public void SetMoneyValue(int newValue)
    {
        MoneyValue = newValue;

        _clickableView.DisplayClickResult(newValue.ToString());
    }
}
