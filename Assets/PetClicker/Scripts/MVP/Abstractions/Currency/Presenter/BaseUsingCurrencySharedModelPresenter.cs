using System;

public abstract class BaseUsingCurrencySharedModelPresenter : BasePresenter
{
    protected BaseCurrencySharedModel currencySharedModel; 

    public void SetCurrencySharedModel(BaseModel sharedModel) // так как модель прокидывается из контроллера, то тут BaseModel и проверка на то что прокинуто
    {
        if (sharedModel is BaseCurrencySharedModel currencySharedModel)
        {
            this.currencySharedModel = currencySharedModel;
        }
        else
        {
            throw new InvalidCastException("Expected BaseCurrencySharedModel, but received something else.");
        }
    }
}
