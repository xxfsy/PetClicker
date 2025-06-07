using UnityEngine;

public class GameEntrypoint : MonoBehaviour
{
    [SerializeField] private GameObject _mainCanvas;
    [SerializeField] private BaseView _clickerViewPrefab;

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

        ClickController clickController = new ClickController(clickModel, clickView, clickPresenter, moneySharedModel);
        clickController.InitializeLayers();


    }
}
