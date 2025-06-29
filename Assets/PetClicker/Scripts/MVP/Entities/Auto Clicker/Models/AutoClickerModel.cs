﻿public class AutoClickerModel : BaseModel, IAutoClickerModel, ISaveableModel
{
    public int IncomePerSecond { get; private set; } 

    public void SetNewValueForIncomePerSecond(int newValue)
    {
        IncomePerSecond = newValue;

        view.DisplayNewDataFromModel(IncomePerSecond.ToString());
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

            view.DisplayNewDataFromModel(IncomePerSecond.ToString());
        }
        else
        {
            return;
        }
    }

}
