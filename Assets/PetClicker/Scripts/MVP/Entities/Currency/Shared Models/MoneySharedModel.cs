public class MoneySharedModel : BaseCurrencySharedModel
{
    private float _amountOfMoney;

    public override float GetCurrentAmountOfCurrency()
    {
        return _amountOfMoney;
    }

    public override void SetNewCurrencyAmount(float newValue)
    {
        _amountOfMoney = newValue;

        currencyView.DisplayNewCurrencyAmountFromSharedModel(_amountOfMoney.ToString());
    }

    public override void SaveLayer(BaseData baseData)
    {
        if (baseData is GameData gameData && gameData.AmountOfMoney != _amountOfMoney)
        {
            gameData.AmountOfMoney = _amountOfMoney;
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
            _amountOfMoney = gameData.AmountOfMoney;

            currencyView.DisplayNewCurrencyAmountFromSharedModel(_amountOfMoney.ToString());
        }
        else
        {
            return;
        }
    }
}
