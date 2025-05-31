public class ClickPresenter : BasePresenter, IClickablePresenter
{
    // TODO: обновлять модель при handleClick-е, мб что-то еще надо сделать посмотреть видос про MVP мб что-то еще презентер делал кроме тригера модели
    // т.к. Presenter обрабатывает клики с вида и изменяет модель, то логика обновления денег должна лежать тут, а модель должна просто меняться, а не содержать в себе логику изменения денег

    private IClickableModel _clickableModel => _model as IClickableModel;

    public ClickPresenter(BaseModel model) : base(model)
    {

    }

    public void HandleClick()
    {
        UpdateMoneyValue();
    }

    public void UpdateMoneyValue()
    {
        throw new System.NotImplementedException();
    }
}
