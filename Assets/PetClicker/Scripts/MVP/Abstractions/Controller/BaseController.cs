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

    //public abstract void InitLayers(); // подумать сделать абстрактным или нет, если нет то надо будет делать проверку то что поля не пустые либо через ?. делать
}
