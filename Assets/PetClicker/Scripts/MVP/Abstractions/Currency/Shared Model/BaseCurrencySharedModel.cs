public abstract class BaseCurrencySharedModel : BaseSaveableModel
{
    protected BaseCurrencyView currencyView => view as BaseCurrencyView; // мб еще так что-то вынести из реализаций как вот ссылка на слой после каста. По идее и является алиасом который советовал чат

    //public int CurrencyAmount { get; protected set; } // надо отрефакторить, это детали конкретной реализации, ведь у нас может быть не обязательно валюта в виде денег, в общем подумать
    // MoneyValue свойство и метод SetNewMoneyValue надо вынести в конкретную реализацию MoneySharedModel и подумать что должно быть тут в абстракции.

    public abstract float GetCurrentAmountOfCurrency(); // мб все таки сделать свойство одно, типа просто кол-во, а кол-во чего конкретного будет понятно по названию конкретной реализации. Типа в тут будет просто Автосвойство Amount как CurrencyAmount, а Amount чего будет понятно по названию класса конкретной реализации. В общем подумать еще по поводу этого класса и как сделать базовый и наследников валюты.

    public abstract void SetNewCurrencyAmount(float newValue); // float т.к. валюта может быть дробной
}
