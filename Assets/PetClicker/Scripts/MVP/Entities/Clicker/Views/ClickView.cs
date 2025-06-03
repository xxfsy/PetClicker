using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ClickView : BaseView, IClickableView, IUsingSharedModel
{
    // TODO: сделать какой-то колбэк или подумать как прокинуть какие действия надо сделать чтобы обновить ui. Хотя мб текущая строка норм, ведь это не ответственность модели, решать какой колбэк
    // кидать вьюшке, она просто передает значение, а вьюшка сама решает что делать со значением. Тогда да, все норм, оcтавить строку. Тогда доделать обновление текста

    private IClickablePresenter _clickablePresenter => _presenter as IClickablePresenter;

    private SharedModel _moneySharedModel;

    [SerializeField] private TextMeshPro _textForClickData;
    [SerializeField] private TextMeshPro _moneyText;

    [SerializeField] private Button _clickerButton;

    private void OnEnable()
    {
        _clickerButton.onClick.AddListener(OnClickerClicked);

        SubscribeToSharedModel();
    }

    private void OnDisable()
    {
        _clickerButton.onClick.RemoveListener(OnClickerClicked);

        UnsubscribeFromSharedModel();
    }

    public void OnClickerClicked()
    {
        _clickablePresenter?.HandleClick();
    }

    public void DisplayClickResult(string newValue)
    {
        _textForClickData.SetText(newValue);
    }

    public void SetSharedModel(SharedModel sharedModel)
    {
        _moneySharedModel = sharedModel;
    }

    public void SubscribeToSharedModel()
    {
        _moneySharedModel.ViewsNotify += DisplayClickResultFromSharedModel;
    }

    public void UnsubscribeFromSharedModel()
    {
        _moneySharedModel.ViewsNotify -= DisplayClickResultFromSharedModel;
    }

    public void DisplayClickResultFromSharedModel(string newValue)
    {
        _moneyText.SetText(newValue);
    }
}
