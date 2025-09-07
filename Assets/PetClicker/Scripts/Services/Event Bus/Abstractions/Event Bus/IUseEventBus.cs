// интерфейс т.к. у нас ивент бас могут использовать и презентеры и сервисы в будущем. Если шаред модель нужна будет и сервисам, то можно будет из BaseUsingSharedModelPresenter переписать под интерфейс такой же тоже в будущем
public interface IUseEventBus
{
    public void SetEventBus(BaseEventBus eventBus);
}
