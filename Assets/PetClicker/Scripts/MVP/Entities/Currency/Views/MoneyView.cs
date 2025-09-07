using TMPro;
using UnityEngine;

public class MoneyView : BaseCurrencyView
{
    [SerializeField] private TextMeshProUGUI _moneyText;

    public override void DisplayNewCurrencyAmountFromSharedModel(string newValue)
    {
        _moneyText.SetText(newValue);
    }
}
