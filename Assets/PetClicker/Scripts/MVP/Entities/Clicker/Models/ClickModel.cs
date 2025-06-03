public class ClickModel : BaseModel, IClickableModel
{
    // TODO: обновить деньги, обновить ui после обновления денег - либо в UpdateMoneyData либо в отдельном методе (спросить)

    private IClickableView _clickableView => view as IClickableView;

    public int ClicksValue { get; private set; }

    public void SetNewValueAfterClick(int newValue)
    {
        ClicksValue = newValue;

        _clickableView?.DisplayClickResult(newValue.ToString());
    }
}
