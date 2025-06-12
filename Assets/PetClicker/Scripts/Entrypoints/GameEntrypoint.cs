using UnityEngine;
using System.Collections.Generic;

public class GameEntrypoint : MonoBehaviour
{
    [SerializeField] private GameObject _mainCanvas;
    [SerializeField] private BaseView _clickerViewPrefab;
    [SerializeField] private BaseSaveLoadManager _saveLoadManagerPrefab;

    private void Awake()
    {
        InitializeGame();
    }

    private void InitializeGame()
    {
        // shared model creating
        BaseSharedModel moneySharedModel = new MoneySharedModel();

        // clicker MVP trio creating and initializng
        BaseModel clickModel = new ClickModel();
        BaseView clickView = Instantiate(_clickerViewPrefab, _mainCanvas.transform);
        BasePresenter clickPresenter = new ClickPresenter();

        BaseController clickController = new ClickController(clickModel, clickView, clickPresenter, moneySharedModel);
        clickController.InitializeLayers();

        // SaveLoad service creating and initializing
        BaseSaveLoadManager saveLoadManager = Instantiate(_saveLoadManagerPrefab);
        List<ISaveableMVPController> saveableControllers = new List<ISaveableMVPController>()
        {
            clickController as ISaveableMVPController
        };
        List<ISaveableMVPLayer> saveableLayers = new List<ISaveableMVPLayer>()
        {
            moneySharedModel as ISaveableMVPLayer
        };
        BaseSaveLoadService playerPrefsJsonSaveServise = new PlayerPrefsJsonSaveServise();
        saveLoadManager.Initialize(saveableControllers, saveableLayers, playerPrefsJsonSaveServise, PlayerPrefsJsonSaveServise.SaveKeys.GameDataKey); 
    }
}
