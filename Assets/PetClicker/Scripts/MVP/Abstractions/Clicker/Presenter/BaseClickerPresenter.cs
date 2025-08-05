public abstract class BaseClickerPresenter : BaseUsingSharedModelPresenter
{
    public abstract void HandleClick();

    protected abstract void UpdateModelAfterClick();
}
