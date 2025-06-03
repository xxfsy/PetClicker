using System.Collections.Generic;

public abstract class BaseController
{
    protected BaseModel model { get; private set; }

    protected BaseView view { get; private set; }

    protected BasePresenter presenter { get; private set; }

    protected SharedModel sharedModel { get; private set; } //nullable

    public BaseController(BaseModel model, BaseView view, BasePresenter presenter, SharedModel sharedModel)
    {
        this.model = model;
        this.view = view;
        this.presenter = presenter;
        this.sharedModel = sharedModel;
    }

    public abstract void InitLayers(); // �������� ������� ����������� ��� ���, ���� ��� �� ���� ����� ������ �������� �� ��� ���� �� ������ ���� ����� ?. ������. �� ������� �����������, 
    // �.�. ������ ������������� � ������� ����������� ���� - ���-�� ������� ������, ���-�� ������������ IUsingSharedModel. ��� ���????? �������� ��� � �����, �� ���� ��� ������� ��� �� �����������
}
