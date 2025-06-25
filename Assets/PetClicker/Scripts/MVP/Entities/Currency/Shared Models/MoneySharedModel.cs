public class MoneySharedModel : BaseModel, ICurrencySharedModel, ISaveableModel
{
    public int MoneyValue { get; private set; }

    public void SetNewMoneyValue(int newValue)
    {
        MoneyValue = newValue;

        view.DisplayNewDataFromModel(MoneyValue.ToString());
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

            view.DisplayNewDataFromModel(MoneyValue.ToString());
        }
        else
        {
            return;
        }
    }
}
