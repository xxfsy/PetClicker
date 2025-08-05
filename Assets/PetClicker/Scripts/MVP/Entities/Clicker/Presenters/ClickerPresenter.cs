using System;

public class ClickerPresenter : BaseClickerPresenter
{
    // т.к. Presenter обрабатывает клики с вида и изменяет модель, то логика обновления денег должна лежать тут, а модель должна просто меняться, а не содержать в себе логику изменения денег

    private BaseClickerModel _clickerModel => model as BaseClickerModel;

    private BaseModel _moneySharedModel;

    public override void SetSharedModel(BaseModel sharedModel)
    {
        _moneySharedModel = sharedModel;
    }

    public override void HandleClick()
    {
        UpdateModelAfterClick();
        UpdateSharedModel();
    }

    protected override void UpdateModelAfterClick()
    {
        int newValue = _clickerModel.ClicksCount;

        newValue++;

        _clickerModel?.SetNewValueAfterClick(newValue);
    }

    protected override void UpdateSharedModel()
    {
        if (_moneySharedModel is BaseCurrencySharedModel currencySharedModel)
        {
            int newValue = currencySharedModel.MoneyValue;

            newValue++;

            currencySharedModel.SetNewCurrencyValue(newValue);
        }
        else
        {
            throw new InvalidCastException("Expected ICurrencySharedModel, but received something else.");
            //return;
        }
    }
}
