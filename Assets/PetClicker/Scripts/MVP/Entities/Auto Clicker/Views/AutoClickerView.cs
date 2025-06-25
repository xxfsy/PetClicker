using TMPro;
using UnityEngine;

public class AutoClickerView : BaseView
{
    [SerializeField] private TextMeshProUGUI _textForAutoClickData;

    [SerializeField] private string _prefixForIncomePerSecond = "/sec";


    public override void DisplayNewDataFromModel(string newValue)
    {
        _textForAutoClickData.SetText(newValue + _prefixForIncomePerSecond);
    }
}
