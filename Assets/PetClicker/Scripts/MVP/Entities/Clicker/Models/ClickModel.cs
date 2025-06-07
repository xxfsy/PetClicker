public class ClickModel : BaseModel, IClickableModel, ISaveableLayer
{
    private IClickableView _clickableView => view as IClickableView;

    public int ClicksValue { get; private set; }

    public void SetNewValueAfterClick(int newValue)
    {
        ClicksValue = newValue;

        _clickableView?.DisplayClickResult(newValue.ToString());
    }

    public void SaveLayer(BaseData baseData)
    {
        if (baseData is GameData gameData && gameData.ClicksCount != ClicksValue)
        {
            gameData.ClicksCount = ClicksValue;
        }
        else
        {
            return;
        }
    }

    public void LoadLayer(BaseData baseData)
    {
        if (baseData is GameData gameData)
        {
            ClicksValue = gameData.ClicksCount;
        }
        else
        {
            return;
        }
    }
}
