public abstract class BaseClickerPresenter : BaseUsingSharedModelPresenter
{
    protected BaseClickerModel clickerModel => model as BaseClickerModel; // мб еще так что-то вынести из реализаций как вот ссылка на слой после каста

    public abstract void HandleClick();

    protected abstract void UpdateModelsAfterClick();

}
