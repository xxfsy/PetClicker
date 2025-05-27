public interface IClickableView
{
    public void OnClickerClicked();

    public void UpdateUIAfterClick(string newValue); // как передать что надо сделать, как именно обновить UI, через callback? Спросить норм если строкой передавать новое значение, 
    // написал в ClickView почему я думаю что строка норм
}
