public interface IClickerModel
{
    public int ClicksCount { get; }

    public void SetNewValueAfterClick(int newValue);
}
