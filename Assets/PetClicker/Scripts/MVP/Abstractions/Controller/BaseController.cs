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

    //public abstract void InitLayers(); // �������� ������� ����������� ��� ���, ���� ��� �� ���� ����� ������ �������� �� ��� ���� �� ������ ���� ����� ?. ������
}
