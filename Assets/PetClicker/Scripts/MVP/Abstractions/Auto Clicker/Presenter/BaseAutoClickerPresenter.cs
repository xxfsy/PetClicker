public abstract class BaseAutoClickerPresenter : BaseUsingCurrencySharedModelPresenter, ITickable
{
    protected BaseAutoClickerModel autoClickerModel => model as BaseAutoClickerModel; 

    public abstract float TickCooldownInSeconds { get; protected set; }

    public abstract void SetTickCooldown(float tickCooldownInSeconds);
    public abstract void Tick();

    protected abstract void UpdateSharedModel();
}
