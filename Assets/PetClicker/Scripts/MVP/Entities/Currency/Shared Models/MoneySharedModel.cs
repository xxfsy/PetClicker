using System;

public class MoneySharedModel : BaseSharedModel, ICurrencySharedModel, ISaveableMVPLayer
{
    public int MoneyValue { get; private set; }

    public void SetNewMoneyValue(int newValue)
    {
        MoneyValue = newValue;

        foreach (IUsingSharedModelView usingSharedModelView in views)
            usingSharedModelView.DisplayNewDataFromSharedModel(MoneyValue.ToString());
    }

    public void SaveLayer(BaseData baseData)
    {
        if (baseData is GameData gameData && gameData.MoneyCount != MoneyValue)
        {
            gameData.MoneyCount = MoneyValue;
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
            MoneyValue = gameData.MoneyCount;

            foreach (IUsingSharedModelView usingSharedModelView in views)
                usingSharedModelView.DisplayNewDataFromSharedModel(MoneyValue.ToString());
        }
        else
        {
            return;
        }
    }
}
