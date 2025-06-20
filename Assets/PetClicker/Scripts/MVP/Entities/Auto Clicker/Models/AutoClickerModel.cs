public class AutoClickerModel : BaseModel, IAutoClickerModel, ISaveableMVPLayer
{
    private IAutoClickerView _autoClickerView => view as IAutoClickerView;

    public int IncomePerSecond { get; private set; } 

    public void SetNewValueForIncomePerSecond(int newValue)
    {
        IncomePerSecond = newValue;

        _autoClickerView.DisplayNewDataFromModel(IncomePerSecond.ToString());
    }

    public void SaveLayer(BaseData baseData)
    {
        if (baseData is GameData gameData && gameData.AutoClickerIncomePerSecond != IncomePerSecond)
        {
            gameData.AutoClickerIncomePerSecond = IncomePerSecond;
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
            IncomePerSecond = gameData.AutoClickerIncomePerSecond;

            _autoClickerView.DisplayNewDataFromModel(IncomePerSecond.ToString());
        }
        else
        {
            return;
        }
    }

}
