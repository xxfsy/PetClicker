public abstract class BaseAutoClickerPresenter : BaseUsingCurrencySharedModelPresenter, ITickable
{
    protected BaseAutoClickerModel autoClickerModel => model as BaseAutoClickerModel; // мб еще так что-то вынести из реализаций как вот ссылка на слой после каста

    public abstract float TickCooldownInSeconds { get; protected set; }

    public abstract void SetTickCooldown(float tickCooldownInSeconds);
    public abstract void Tick();

    protected abstract void UpdateSharedModel();
}
