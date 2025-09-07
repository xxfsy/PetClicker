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

        //надо наверное вьюшку сначала инициализировать наверное, или я не знаю, у меня по идее данные не обновяться, т.к. у меня загружается сейв, модель пытается сказать пустому словарю нарисовать что-то и все на этом, в общем надо на счет этого подумать, ведь у меня пустые вьюшки будут инсташиейтиться без данных, т.к. загрузка произошла до создания вьюшек скорее всего
        if (model is BaseUpgradesShopModel upgradesShopModel) upgradesShopModel.InitializeUpgradesShopModel(_shopContentConfig);

        if (view is BaseUpgradesShopView upgradesShopView) upgradesShopView.InitializeUpgradesShopView(_shopContentConfig);
    }
}
