public class UpgradesShopSaveableController : SaveableController
{
    private readonly BaseShopContent _shopContentConfig;

    public UpgradesShopSaveableController(BaseModel model, BaseView view, BasePresenter presenter, BaseShopContent shopContentConfig, BaseModel sharedModel = null, BaseEventBus eventBus = null) : base(model, view, presenter, sharedModel, eventBus)
    {
        _shopContentConfig = shopContentConfig;
    }

    public override void InitializeLayers()
    {
        base.InitializeLayers();

        if (model is BaseUpgradesShopModel upgradesShopModel) upgradesShopModel.InitializeUpgradesShopModel(_shopContentConfig);

        if (view is BaseUpgradesShopView upgradesShopView) upgradesShopView.InitializeUpgradesShopView(_shopContentConfig);
    }
}
