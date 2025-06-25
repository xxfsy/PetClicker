using TMPro;
using UnityEngine;

public class MoneyView : BaseView
{
    [SerializeField] private TextMeshProUGUI _moneyText;

    public override void DisplayNewDataFromModel(string newValue)
    {
        _moneyText.SetText(newValue);
    }
}
