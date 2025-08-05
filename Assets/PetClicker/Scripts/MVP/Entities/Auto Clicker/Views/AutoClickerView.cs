using TMPro;
using UnityEngine;

public class AutoClickerView : BaseView
{
    [SerializeField] private TextMeshProUGUI _textForAutoClickValue;

    [SerializeField] private string _prefixForIncomePerSecond = "/sec";


    public override void DisplayNewDataFromModel(string newValue)
    {
        _textForAutoClickValue.SetText(newValue + _prefixForIncomePerSecond);
    }
}
