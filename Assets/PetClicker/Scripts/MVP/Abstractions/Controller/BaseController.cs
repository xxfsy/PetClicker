using System.Collections.Generic;

public abstract class BaseController
{
    protected BaseModel _model { get; private set; }

    protected BaseView _view { get; private set; }

    protected BasePresenter _presenter { get; private set; }

    public BaseController(BaseModel model, BaseView view, BasePresenter presenter)
    {
        _model = model;
        _view = view;
        _presenter = presenter;
    }

    public abstract void InitLayers(); // подумать сделать абстрактным или нет, если нет то надо будет делать проверку то что поля не пустые либо через ?. делать. Да сделать абстрактным, 
    // т.к. логика инициализации у каждого контроллера своя - где-то обычные вьюшки, где-то использующие IUsingSharedModel. Или нет????? подумать еще в общем, мб если что сделать его не абстрактным
}
