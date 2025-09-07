public abstract class BaseClickerView : BaseView
{
    protected abstract void OnClickerClicked();

    public abstract void DisplayNewClicksCountFromModel(string newValue);

    public abstract void DisplayNewIncomePerClickFromModel(string newValue);
}
