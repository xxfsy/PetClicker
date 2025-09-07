using System.Collections.Generic;
using UnityEngine;

public class GameEntrypoint : MonoBehaviour
{
    [Header("Debbuging")]
    [SerializeField] private bool _resetPlayerPrefs;

    [Header("Loading Screen")]
    [SerializeField] private GameObject _loadingScreen; // добавить потом включение и выключения экрана загрузки

    [Header("Canvases")]
    [SerializeField] private GameObject _mainCanvas;

    [Header("Root GameObjects for screens")]
    [SerializeField] private GameObject _mainScreenRoot;
    [SerializeField] private GameObject _upgradeScreenRoot;

    [Header("Views")]
    [SerializeField] private BaseView _clickerViewPrefab;
    [SerializeField] private BaseView _autoClickerViewPrefab;
    [SerializeField] private BaseView _upgradesShopViewPrefab;
    [SerializeField] private BaseCurrencyView _moneyViewPrefab;

    [Header("Services")]
    [SerializeField] private BaseSaveLoadManager _saveLoadManagerPrefab;
    [SerializeField] private BaseTickService _tickServicePrefab;
    [SerializeField] private BaseUIScreenSwitcherService _uiScreenSwitcherServicePrefab;

    [Header("TickCooldowns")]
    [SerializeField] private float _tickCooldownForAutoClicker = 1f;
    [SerializeField] private float _tickCooldownForSaveLoadManager = 30f;

    [Header("Configs")]
    [SerializeField] private BaseShopContent _shopContentConfig;

    private void Awake()
    {
        //Debugging
#if UNITY_EDITOR

        if (_resetPlayerPrefs)
        {
            PlayerPrefs.DeleteAll();
        }

#endif

        InitializeGame();
    }

    private void InitializeGame() // Вообще надо по идее наверное создать какой-то интерфейс или что-то типа того чтобы у ентри поинта не было доступа к методам Intialize у слоев, чтобы нельзя было ничего тут проинициализировать, кроме shared моделей, ведь этим занимается контроллер.
    {
        // Loading screen turning on
        //_loadingScreen.SetActive(true);

        // Event bus creating
        BaseEventBus eventBus = new EventBus();

        // Shared models creating and initializing. Shared models - инициализируются тут, обычные модели - внутри контроллера
        BaseCurrencySharedModel moneySharedModel = new MoneySharedModel(); // надо ли все переделывать под абстракцию текущего уровня как тут? будет ли так соблюдаться DIP? Надо ли тогда все остальные трио так же переделывать под BaseClickerModel вместо BaseModel и тд (?)
        BaseCurrencyView moneyView = Instantiate(_moneyViewPrefab, _mainScreenRoot.transform);
        moneySharedModel.Initialize(moneyView);

        // Clicker MVP trio creating and initializng
        BaseModel clickerModel = new ClickerModel();
        BaseView clickerView = Instantiate(_clickerViewPrefab, _mainScreenRoot.transform);
        BasePresenter clickerPresenter = new ClickerPresenter();

        BaseController clickerController = new SaveableController(clickerModel, clickerView, clickerPresenter, moneySharedModel, eventBus);
        clickerController.InitializeLayers();

        // Auto-clicker MVP trio creating and initializing
        BaseModel autoClickerModel = new AutoClickerModel();
        BaseView autoClickerView = Instantiate(_autoClickerViewPrefab, _mainScreenRoot.transform);
        BasePresenter autoClickerPresenter = new AutoClickerPresenter();

        BaseController autoClickerController = new AutoClickerSaveableController(autoClickerModel, autoClickerView, autoClickerPresenter, _tickCooldownForAutoClicker, moneySharedModel, eventBus);
        autoClickerController.InitializeLayers();

        // Upgrades shop MVP trio creating and initializing
        BaseModel upgradesShopModel = new UpgradesShopModel();
        BaseView upgradesShopView = Instantiate(_upgradesShopViewPrefab, _upgradeScreenRoot.transform);
        BasePresenter upgradesShopPresenter = new UpgradesShopPresenter();

        BaseController upgradesShopController = new UpgradesShopSaveableController(upgradesShopModel, upgradesShopView, upgradesShopPresenter, _shopContentConfig, moneySharedModel, eventBus);
        upgradesShopController.InitializeLayers();

        // UI Screen Switcher Service creating and initializing
        BaseUIScreenSwitcherService uiScreenSwitcherService = Instantiate(_uiScreenSwitcherServicePrefab, _mainCanvas.transform);
        uiScreenSwitcherService.Initialize(_mainScreenRoot, _upgradeScreenRoot);

        // SaveLoad service creating and initializing
        BaseSaveLoadManager saveLoadManager = Instantiate(_saveLoadManagerPrefab);
        List<BaseSaveableController> saveableControllers = new List<BaseSaveableController>()
        {
            clickerController as BaseSaveableController,
            autoClickerController as BaseSaveableController,
            upgradesShopController as BaseSaveableController
        };
        List<BaseSaveableModel> saveableSharedModels = new List<BaseSaveableModel>() // обычные модели сохраняются через контроллеры, шаредмодели отдельно напрямую через saveLoadManager
        {
            moneySharedModel as BaseSaveableModel
        };
        BaseSaveLoadService playerPrefsJsonSaveServise = new PlayerPrefsJsonSaveLoadService();
        saveLoadManager.Initialize(saveableControllers, saveableSharedModels, playerPrefsJsonSaveServise, SaveKeys.GameDataKey);
        (saveLoadManager as ITickable)?.SetTickCooldown(_tickCooldownForSaveLoadManager); // может быть перенести в инит надо

        // Tick service creating and initializing
        BaseTickService tickService = Instantiate(_tickServicePrefab);
        List<ITickable> tickables = new List<ITickable>()
        {
            autoClickerPresenter as ITickable,
            saveLoadManager as ITickable
        };
        foreach (ITickable tickable in tickables)
            tickService.Register(tickable);

        // Loading screen turning off
        //_loadingScreen.SetActive(false);
    }
}
