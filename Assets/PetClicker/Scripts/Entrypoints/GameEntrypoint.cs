using System.Collections.Generic;
using UnityEngine;

public class GameEntrypoint : MonoBehaviour
{
    [Header("Debbuging")]
    [SerializeField] private bool _resetPlayerPrefs;

    [Header("Canvases")]
    [SerializeField] private GameObject _mainCanvas;

    [Header("Root GameObjects for screens")]
    [SerializeField] private GameObject _mainScreenRoot;
    [SerializeField] private GameObject _upgradeScreenRoot;
    [SerializeField] private GameObject _overlayScreenRoot;
    [SerializeField] private GameObject _loadingScreenRoot;

    [Header("Views")]
    [SerializeField] private BaseClickerView _clickerViewPrefab;
    [SerializeField] private BaseAutoClickerView _autoClickerViewPrefab;
    [SerializeField] private BaseUpgradesShopView _upgradesShopViewPrefab;
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

    private void InitializeGame() 
    {
        // Loading screen turning on
        _loadingScreenRoot.SetActive(true);

        // Event bus creating
        BaseEventBus eventBus = new EventBus();

        // Shared models creating and initializing. Shared models - инициализируются тут, обычные модели - внутри контроллера
        BaseCurrencySharedModel moneySharedModel = new MoneySharedModel(); 
        BaseCurrencyView moneyView = Instantiate(_moneyViewPrefab, _overlayScreenRoot.transform);
        moneySharedModel.Initialize(moneyView);

        // Clicker MVP trio creating and initializng
        BaseClickerModel clickerModel = new ClickerModel();
        BaseClickerView clickerView = Instantiate(_clickerViewPrefab, _mainScreenRoot.transform);
        BaseClickerPresenter clickerPresenter = new ClickerPresenter();

        BaseSaveableController clickerController = new SaveableController(clickerModel, clickerView, clickerPresenter, moneySharedModel, eventBus);
        clickerController.InitializeLayers();

        // Auto-clicker MVP trio creating and initializing
        BaseAutoClickerModel autoClickerModel = new AutoClickerModel();
        BaseAutoClickerView autoClickerView = Instantiate(_autoClickerViewPrefab, _mainScreenRoot.transform);
        BaseAutoClickerPresenter autoClickerPresenter = new AutoClickerPresenter();

        BaseSaveableController autoClickerController = new AutoClickerSaveableController(autoClickerModel, autoClickerView, autoClickerPresenter, _tickCooldownForAutoClicker, moneySharedModel, eventBus);
        autoClickerController.InitializeLayers();

        // Upgrades shop MVP trio creating and initializing
        BaseUpgradesShopModel upgradesShopModel = new UpgradesShopModel();
        BaseUpgradesShopView upgradesShopView = Instantiate(_upgradesShopViewPrefab, _upgradeScreenRoot.transform);
        BaseUpgradesShopPresenter upgradesShopPresenter = new UpgradesShopPresenter();

        BaseSaveableController upgradesShopController = new UpgradesShopSaveableController(upgradesShopModel, upgradesShopView, upgradesShopPresenter, _shopContentConfig, moneySharedModel, eventBus);
        upgradesShopController.InitializeLayers();

        // UI Screen Switcher Service creating and initializing
        BaseUIScreenSwitcherService uiScreenSwitcherService = Instantiate(_uiScreenSwitcherServicePrefab, _mainCanvas.transform);
        uiScreenSwitcherService.Initialize(_mainScreenRoot, _upgradeScreenRoot);

        // SaveLoad service creating and initializing
        BaseSaveLoadManager saveLoadManager = Instantiate(_saveLoadManagerPrefab);
        List<BaseSaveableController> saveableControllers = new List<BaseSaveableController>()
        {
            clickerController,
            autoClickerController, 
            upgradesShopController 
        };
        List<BaseSaveableModel> saveableSharedModels = new List<BaseSaveableModel>() // обычные модели сохраняются через контроллеры, шаредмодели отдельно напрямую через saveLoadManager
        {
            moneySharedModel
        };
        BaseSaveLoadService playerPrefsJsonSaveServise = new PlayerPrefsJsonSaveLoadService();
        saveLoadManager.Initialize(saveableControllers, saveableSharedModels, playerPrefsJsonSaveServise, SaveKeys.GameDataKey);
        (saveLoadManager as ITickable)?.SetTickCooldown(_tickCooldownForSaveLoadManager); 

        // Tick service creating and initializing
        BaseTickService tickService = Instantiate(_tickServicePrefab);
        List<ITickable> tickables = new List<ITickable>()
        {
            autoClickerPresenter,
            saveLoadManager as ITickable
        };
        foreach (ITickable tickable in tickables)
            tickService.Register(tickable);

        // Loading screen turning off
        _loadingScreenRoot.SetActive(false);
    }
}
