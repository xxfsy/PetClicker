using TMPro;
using UnityEngine;

public class AutoClickerView : BaseAutoClickerView
{
    [SerializeField] private TextMeshProUGUI _incomePerSecondText;

    [SerializeField] private string _prefixForIncomePerSecond = "/sec";


    public override void DisplayNewIncomePerSecondFromModel(string newValue)
    {
        _incomePerSecondText.SetText(newValue + _prefixForIncomePerSecond);
    }
}
