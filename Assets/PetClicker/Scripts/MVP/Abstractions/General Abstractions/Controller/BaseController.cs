using System.Collections.Generic;

public abstract class BaseController
{
    protected BaseModel model { get; private set; }

    protected BaseView view { get; private set; }

    protected BasePresenter presenter { get; private set; }

    protected BaseSharedModel sharedModel { get; private set; } //nullable

    public BaseController(BaseModel model, BaseView view, BasePresenter presenter, BaseSharedModel sharedModel)
    {
        this.model = model;
        this.view = view;
        this.presenter = presenter;
        this.sharedModel = sharedModel;
    }

    public abstract void InitializeLayers(); // подумать сделать абстрактным или нет, если нет то надо будет делать проверку то что поля не пустые либо через ?. делать. Да сделать абстрактным, 
    // т.к. логика инициализации у каждого контроллера своя - где-то обычные вьюшки, где-то использующие IUsingSharedModel. Или нет????? подумать еще в общем, мб если что сделать его не абстрактным
}
