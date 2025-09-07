public class MoneySharedModel : BaseCurrencySharedModel
{
    public override void SetNewCurrencyAmount(int newValue)
    {
        CurrentAmount = newValue;

        currencyView.DisplayNewCurrencyAmountFromSharedModel(CurrentAmount.ToString());
    }

    public override void SaveLayer(BaseData baseData)
    {
        if (baseData is GameData gameData && gameData.AmountOfMoney != CurrentAmount)
        {
            gameData.AmountOfMoney = CurrentAmount;
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
            CurrentAmount = gameData.AmountOfMoney;

            currencyView.DisplayNewCurrencyAmountFromSharedModel(CurrentAmount.ToString());
        }
        else
        {
            return;
        }
    }
}
