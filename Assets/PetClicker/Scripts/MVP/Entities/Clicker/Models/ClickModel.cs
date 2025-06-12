using Unity.Collections.LowLevel.Unsafe;

public class ClickModel : BaseModel, IClickableModel, ISaveableMVPLayer
{
    private IClickableView _clickableView => view as IClickableView;

    public int ClicksValue { get; private set; }

    public void SetNewValueAfterClick(int newValue)
    {
        ClicksValue = newValue;

        _clickableView?.DisplayNewDataFromModel(ClicksValue.ToString());
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

            _clickableView?.DisplayNewDataFromModel(ClicksValue.ToString());
        }
        else
        {
            return;
        }
    }
}
