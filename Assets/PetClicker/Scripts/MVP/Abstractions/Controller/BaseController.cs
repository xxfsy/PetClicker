using System.Collections.Generic;

public abstract class BaseController<T> where T : IControllable
{
    // TODO: finish this class 

    protected readonly List<T> components = new(); // ����� �� �������� ���?????? �� ������� ����������� ��������� �� �������� ��� ������. ����� ���-�� ������� ����������� ��������� � ������� �� ��������

    public abstract void InitAll();
}
