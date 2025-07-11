public class AutoClickerSaveableController : SaveableController
{
    private readonly float _tickCooldownInSeconds;

    public AutoClickerSaveableController(BaseModel model, BaseView view, BasePresenter presenter, float tickCooldown, BaseModel sharedModel = null) : base(model, view, presenter, sharedModel)
    {
        _tickCooldownInSeconds = tickCooldown;
    }

    public override void InitializeLayers()
    {
        base.InitializeLayers();

        if (presenter is ITickable tickablePresenter) tickablePresenter.SetTickCooldown(_tickCooldownInSeconds);
    }
}
