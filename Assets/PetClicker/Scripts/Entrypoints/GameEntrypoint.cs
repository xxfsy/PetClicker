using UnityEngine;
using System.Collections.Generic;

public class GameEntrypoint : MonoBehaviour
{
    [Header("Canvases")]
    [SerializeField] private GameObject _mainCanvas;

    [Header("Views")]
    [SerializeField] private BaseView _clickerViewPrefab;
    [SerializeField] private BaseView _autoClickerViewPrefab;
    [SerializeField] private BaseView _moneyViewPrefab;

    [Header("Services")]
    [SerializeField] private BaseSaveLoadManager _saveLoadManagerPrefab;
    [SerializeField] private BaseTickService _tickServicePrefab;

    [Header("TickCooldowns")]
    [SerializeField] private float _tickCooldownForAutoClicker = 1f;
    [SerializeField] private float _tickCooldownForSaveLoadManager = 30f;

    private void Awake()
    {
        InitializeGame();
    }

    private void InitializeGame()
    {
        // shared models creating and initializing. Shared models - инициализируются тут, обычные модели - внутри контроллера
        BaseModel moneySharedModel = new MoneySharedModel();
        BaseView moneyView = Instantiate(_moneyViewPrefab, _mainCanvas.transform);
        moneySharedModel.Initialize(moneyView);

        // clicker MVP trio creating and initializng
        BaseModel clickerModel = new ClickerModel();
        BaseView clickerView = Instantiate(_clickerViewPrefab, _mainCanvas.transform);
        BasePresenter clickerPresenter = new ClickerPresenter();

        BaseController clickerController = new SaveableController(clickerModel, clickerView, clickerPresenter, moneySharedModel);
        clickerController.InitializeLayers();

        // auto-clicker MVP trio creating and initializing
        BaseModel autoClickerModel = new AutoClickerModel();
        BaseView autoClickerView = Instantiate(_autoClickerViewPrefab, _mainCanvas.transform);
        BasePresenter autoClickerPresenter = new AutoClickerPresenter();

        BaseController autoClickerController = new AutoClickerSaveableController(autoClickerModel, autoClickerView, autoClickerPresenter, _tickCooldownForAutoClicker, moneySharedModel);
        autoClickerController.InitializeLayers();

        // SaveLoad service creating and initializing
        BaseSaveLoadManager saveLoadManager = Instantiate(_saveLoadManagerPrefab);
        List<ISaveableMVPController> saveableControllers = new List<ISaveableMVPController>()
        {
            clickerController as ISaveableMVPController,
            autoClickerController as ISaveableMVPController
        };
        List<ISaveableModel> saveableSharedModels = new List<ISaveableModel>() // обычные модели сохраняются внутри контроллеров, шаредмодели отдельно напрямую через saveLoadManager
        {
            moneySharedModel as ISaveableModel
        };
        BaseSaveLoadService playerPrefsJsonSaveServise = new PlayerPrefsJsonSaveServise();
        (saveLoadManager as ITickable).SetTickCooldown(_tickCooldownForSaveLoadManager); 
        saveLoadManager.Initialize(saveableControllers, saveableSharedModels, playerPrefsJsonSaveServise, PlayerPrefsJsonSaveServise.SaveKeys.GameDataKey);

        // Tick service creating and initializing
        BaseTickService tickService = Instantiate(_tickServicePrefab);
        List<ITickable> tickables = new List<ITickable>()
        {
            autoClickerPresenter as ITickable,
            saveLoadManager as ITickable
        };
        foreach (ITickable tickable in tickables)
            tickService.Register(tickable);
    }
}
