using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ClickView : BaseView, IClickableView, IUsingSharedModelView
{
    // TODO: сделать какой-то колбэк или подумать как прокинуть какие действия надо сделать чтобы обновить ui. Хотя мб текущая строка норм, ведь это не ответственность модели, решать какой колбэк
    // кидать вьюшке, она просто передает значение, а вьюшка сама решает что делать со значением. Тогда да, все норм, сотавить строку. Тогда доделать обновление текста

    private IClickablePresenter _clickablePresenter => _presenter as IClickablePresenter;

    [SerializeField] private TextMeshPro _moneyText;

    [SerializeField] private Button _clickerButton;

    private void OnEnable()
    {
        _clickerButton.onClick.AddListener(OnClickerClicked);
    }

    private void OnDisable()
    {
        _clickerButton.onClick.RemoveListener(OnClickerClicked);
    }

    public void OnClickerClicked()
    {
        _clickablePresenter?.HandleClick();
    }

    public void DisplayClickResult(string newValue)
    {
        _moneyText.SetText(newValue);
    }

    public void SetSharedModel(SharedModel sharedModel)
    {
        throw new System.NotImplementedException();
    }

    public void SubscribeToModel()
    {
        throw new System.NotImplementedException();
    }

    public void UnsubscribeFromModel()
    {
        throw new System.NotImplementedException();
    }
}
