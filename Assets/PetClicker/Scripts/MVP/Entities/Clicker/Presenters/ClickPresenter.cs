public class ClickPresenter : BasePresenter, IClickablePresenter, IUsingSharedModel
{
    // TODO: обновлять модель при handleClick-е, мб что-то еще надо сделать посмотреть видос про MVP мб что-то еще презентер делал кроме тригера модели
    // т.к. Presenter обрабатывает клики с вида и изменяет модель, то логика обновления денег должна лежать тут, а модель должна просто меняться, а не содержать в себе логику изменения денег

    private IClickableModel _clickableModel => _model as IClickableModel;

    private SharedModel _moneySharedModel;

    public ClickPresenter(BaseModel model) : base(model)
    {

    }

    public void SetSharedModel(SharedModel sharedModel)
    {
        _moneySharedModel = sharedModel;
    }

    public void HandleClick()
    {
        UpdateModelAfterClick();
        UpdateSharedModelAfterClick();
    }

    public void UpdateModelAfterClick()
    {
        int newValue = _clickableModel.ClicksValue;

        newValue++;

        _clickableModel?.SetNewValueAfterClick(newValue);
    }

    public void UpdateSharedModelAfterClick()
    {
        if (_moneySharedModel is ICurrencySharedModel currencySharedModel)
        {
            int newValue = currencySharedModel.MoneyValue;

            newValue++;

            currencySharedModel.SetNewMoneyValue(newValue);
        }
        else
        {
            return;
        }
    }
}
