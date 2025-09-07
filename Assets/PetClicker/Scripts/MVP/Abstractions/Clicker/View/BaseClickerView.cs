public abstract class BaseClickerView : BaseView
{
    protected BaseClickerPresenter clickerPresenter => presenter as BaseClickerPresenter;

    protected abstract void OnClickerClicked();

    public abstract void DisplayNewClicksCountFromModel(string newValue);

    public abstract void DisplayNewIncomePerClickFromModel(string newValue);
}
