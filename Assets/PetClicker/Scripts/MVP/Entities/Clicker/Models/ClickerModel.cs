﻿public class ClickerModel : BaseModel, IClickerModel, ISaveableModel
{
    public int ClicksCount { get; private set; }

    public void SetNewValueAfterClick(int newValue)
    {
        ClicksCount = newValue;

        view.DisplayNewDataFromModel(ClicksCount.ToString());
    }

    public void SaveLayer(BaseData baseData)
    {
        if (baseData is GameData gameData && gameData.ClicksCount != ClicksCount)
        {
            gameData.ClicksCount = ClicksCount;
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
            ClicksCount = gameData.ClicksCount;

            view.DisplayNewDataFromModel(ClicksCount.ToString());
        }
        else
        {
            return;
        }
    }
}
