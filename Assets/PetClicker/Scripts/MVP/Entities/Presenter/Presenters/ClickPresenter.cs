public class ClickPresenter : BasePresenter, IClickablePresenter
{
    // TODO: обновлять модель при handleClick-е, мб что-то еще надо сделать посмотреть видос про MVP мб что-то еще презентер делал кроме тригера модели

    private IClickableModel _clickableModel => _model as IClickableModel;

    public ClickPresenter(BaseModel model) : base(model)
    {

    }

    public void HandleClick()
    {
        throw new System.NotImplementedException();
    }
}
