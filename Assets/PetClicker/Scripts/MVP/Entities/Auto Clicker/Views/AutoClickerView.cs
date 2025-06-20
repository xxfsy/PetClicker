using TMPro;
using UnityEngine;

public class AutoClickerView : BaseView, IAutoClickerView, IUsingSharedModelView
{
    [SerializeField] private TextMeshProUGUI _textForAutoClickData;
    [SerializeField] private TextMeshProUGUI _moneyText; // вынести в отдельную вьюшку

    [SerializeField] private string _prefixForIncomePerSecond = "/sec";


    public void DisplayNewDataFromModel(string newValue)
    {
        _textForAutoClickData.SetText(newValue + _prefixForIncomePerSecond);
    }

    public void DisplayNewDataFromSharedModel(string newValue) // вынести в отдельную вьюшку
    {
        Debug.Log("Заглушка. *Отображение денег* = " + newValue);
        //_moneyText.SetText(newValue);
    }
}
