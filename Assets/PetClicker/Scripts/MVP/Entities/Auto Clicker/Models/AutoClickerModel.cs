public class AutoClickerModel : BaseAutoClickerModel
{
    public override void SetNewValueForIncomePerSecond(int newValue)
    {
        IncomePerSecond = newValue;

        autoClickerView.DisplayNewIncomePerSecondFromModel(IncomePerSecond.ToString());
    }

    public override void SaveLayer(BaseData baseData)
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

    public override void LoadLayer(BaseData baseData)
    {
        if (baseData is GameData gameData)
        {
            IncomePerSecond = gameData.AutoClickerIncomePerSecond;

            autoClickerView.DisplayNewIncomePerSecondFromModel(IncomePerSecond.ToString());
        }
        else
        {
            return;
        }
    }

}
