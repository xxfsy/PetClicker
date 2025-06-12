using System;

public class MoneySharedModel : BaseSharedModel, ICurrencySharedModel, ISaveableMVPLayer
{
    public int MoneyValue { get; private set; }

    public override event Action<string> ViewsNotify;

    public void SetNewMoneyValue(int newValue)
    {
        MoneyValue = newValue;

        ViewsNotify?.Invoke(MoneyValue.ToString());
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
        }
        else
        {
            return;
        }
    }
}
