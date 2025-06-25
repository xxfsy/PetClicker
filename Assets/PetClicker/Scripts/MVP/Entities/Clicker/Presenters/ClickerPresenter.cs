using System;

public class ClickerPresenter : BasePresenter, IClickerPresenter, IUsingSharedModelPresenter
{
    // т.к. Presenter обрабатывает клики с вида и изменяет модель, то логика обновления денег должна лежать тут, а модель должна просто меняться, а не содержать в себе логику изменения денег

    private IClickerModel _clickerModel => model as IClickerModel;

    private BaseModel _moneySharedModel;

    public void SetSharedModel(BaseModel sharedModel)
    {
        _moneySharedModel = sharedModel;
    }

    public void HandleClick()
    {
        UpdateModelAfterClick();
        UpdateSharedModel();
    }

    public void UpdateModelAfterClick()
    {
        int newValue = _clickerModel.ClicksCount;

        newValue++;

        _clickerModel?.SetNewValueAfterClick(newValue);
    }

    public void UpdateSharedModel()
    {
        if (_moneySharedModel is ICurrencySharedModel currencySharedModel)
        {
            int newValue = currencySharedModel.MoneyValue;

            newValue++;

            currencySharedModel.SetNewMoneyValue(newValue);
        }
        else
        {
            throw new InvalidCastException("Expected ICurrencySharedModel, but received something else.");
            //return;
        }
    }
}
