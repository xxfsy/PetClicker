using UnityEngine;

public class GameEntrypoint : MonoBehaviour
{
    [SerializeField] private GameObject _mainCanvas;
    [SerializeField] private BaseView _clickerViewPrefab;

    private void Awake()
    {
        GameInitialize();
    }

    private void GameInitialize()
    {
        // shared model creating
        SharedModel moneySharedModel = new MoneySharedModel();

        // clicker MVP trio creating and initializng
        BaseModel clickModel = new ClickModel();
        BaseView clickView = Instantiate(_clickerViewPrefab, _mainCanvas.transform);
        BasePresenter clickPresenter = new ClickPresenter();

        ClickController clickController = new ClickController(clickModel, clickView, clickPresenter, moneySharedModel);
        clickController.InitLayers();


    }
}
