using TMPro;
using UnityEngine;

public class ClickView : BaseView, IClickableView
{
    // TODO: сделать какой-то колбэк или подумать как прокинуть какие действия надо сделать чтобы обновить ui. Хотя мб текущая строка норм, ведь это не ответственность модели, решать какой колбэк
    // кидать вьюшке, она просто передает значение, а вьюшка сама решает что делать со значением. Тогда да, все норм, сотавить строку. Тогда доделать обновление текста

    private IClickablePresenter _clickablePresenter => _presenter as IClickablePresenter;

    [SerializeField] private TextMeshPro _moneyText;

    public void OnClickerClicked()
    {
        _clickablePresenter?.HandleClick();
    }

    public void UpdateUIAfterClick(string newValue)
    {
        throw new System.NotImplementedException();
    }
}
