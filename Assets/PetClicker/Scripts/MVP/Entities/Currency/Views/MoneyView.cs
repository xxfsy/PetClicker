using TMPro;
using UnityEngine;

public class MoneyView : BaseCurrencyView
{
    [SerializeField] private TextMeshProUGUI _moneyText;

    [SerializeField] private string _prefixForMoney = "$";

    public override void DisplayNewCurrencyAmountFromSharedModel(string newValue)
    {
        _moneyText.SetText(newValue + _prefixForMoney);
    }
}
