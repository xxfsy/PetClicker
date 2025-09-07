public abstract class BaseCurrencySharedModel : BaseSaveableModel // если появяться другие sharedModel помиму денег (валюты), то сделать абстракцию для sharedModel-ей, по типу BaseSharedModel
{
    protected BaseCurrencyView currencyView => view as BaseCurrencyView; 

    public int CurrentAmount { get; protected set; } 

    public abstract void SetNewCurrencyAmount(int newValue); 
}
