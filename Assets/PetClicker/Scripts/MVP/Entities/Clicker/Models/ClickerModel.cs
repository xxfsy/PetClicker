public class ClickerModel : BaseModel, IClickerModel, ISaveableMVPLayer
{
    private IClickerView _clickerView => view as IClickerView;

    public int ClicksValue { get; private set; }

    public void SetNewValueAfterClick(int newValue)
    {
        ClicksValue = newValue;

        _clickerView?.DisplayNewDataFromModel(ClicksValue.ToString());
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

            _clickerView?.DisplayNewDataFromModel(ClicksValue.ToString());
        }
        else
        {
            return;
        }
    }
}
