public abstract class BaseController
{
    protected BaseModel model { get; private set; }

    protected BaseView view { get; private set; }

    protected BasePresenter presenter { get; private set; }

    //nullable
    protected BaseModel sharedModel { get; private set; } 
    protected BaseEventBus eventBus { get; private set; }

    public BaseController(BaseModel model, BaseView view, BasePresenter presenter, BaseModel sharedModel = null, BaseEventBus eventBus = null) 
    {
        this.model = model;
        this.view = view;
        this.presenter = presenter;
        this.sharedModel = sharedModel;
        this.eventBus = eventBus;
    }

    public virtual void InitializeLayers()
    {
        model.Initialize(view);

        view.Initialize(presenter);

        presenter.Initialize(model);
        if (presenter is BaseUsingCurrencySharedModelPresenter usingSharedModelPresenter) usingSharedModelPresenter.SetCurrencySharedModel(sharedModel); // убрал проверку на null так как если shared model нулл и ты используешь BaseUsingSharedModelPresenter, то тогда либо прокинь шаред модел либо используй BasePresenter 
        if (presenter is IUseEventBus usesEventBusPresenter) usesEventBusPresenter.SetEventBus(eventBus); // норм то что тут проверка или нет? или надо в отдельных контроллерах проверку такую делать, но тогда повтор кода будет
       
    }
}
