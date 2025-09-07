public class ClickerModel : BaseClickerModel
{
    public override void SetNewClicksCountValue(int newValue)
    {
        ClicksCount = newValue;

        clickerView.DisplayNewClicksCountFromModel(ClicksCount.ToString());
    }

    public override void SetNewValueForIncomePerClick(int newValue)
    {
        IncomePerClick = newValue;

        clickerView.DisplayNewIncomePerClickFromModel(IncomePerClick.ToString());
    }

    public override void SaveLayer(BaseData baseData)
    {
        if (baseData is GameData gameData && gameData.ClicksCount != ClicksCount)
        {
            gameData.ClicksCount = ClicksCount;
            gameData.ClickerIncomePerClick = IncomePerClick;
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
            ClicksCount = gameData.ClicksCount;
            IncomePerClick = gameData.ClickerIncomePerClick;

            clickerView.DisplayNewClicksCountFromModel(ClicksCount.ToString());
            clickerView.DisplayNewIncomePerClickFromModel(IncomePerClick.ToString());
        }
        else
        {
            return;
        }
    }
}
