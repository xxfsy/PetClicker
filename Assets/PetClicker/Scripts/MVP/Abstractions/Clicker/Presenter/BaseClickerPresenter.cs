public abstract class BaseClickerPresenter : BaseUsingCurrencySharedModelPresenter
{
    protected BaseClickerModel clickerModel => model as BaseClickerModel; 

    public abstract void HandleClick();

    protected abstract void UpdateModelsAfterClick();

}
