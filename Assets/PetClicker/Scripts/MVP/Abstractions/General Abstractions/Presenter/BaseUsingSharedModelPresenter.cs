using System;

public abstract class BaseUsingSharedModelPresenter : BasePresenter
{
    protected BaseCurrencySharedModel currencySharedModel; // вынес поле и сеттер сюда в общем, так как вроде реализация везде одинаковая сеттера ну и поле часть абстрактного класса, как в BasePresenter

    public void SetSharedModel(BaseModel sharedModel) // мб переделать под BaseCurrencySharedModel а не BaseModel (?)
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
