public class ClickModel : BaseModel, IClickableModel
{
    // TODO: обновить деньги, обновить ui после обновления денег - либо в UpdateMoneyData либо в отдельном методе (спросить)

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
