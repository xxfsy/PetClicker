public interface IClickableView
{
    public void OnClickerClicked();

    public void UpdateUIAfterClick(string newValue); // ��� �������� ��� ���� �������, ��� ������ �������� UI, ����� callback? �������� ���� ���� ������� ���������� ����� ��������, 
    // ������� � ClickView ������ � ����� ��� ������ ����
}
