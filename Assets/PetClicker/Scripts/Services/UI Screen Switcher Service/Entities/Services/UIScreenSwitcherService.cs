using UnityEngine;
using UnityEngine.UI;

public class UIScreenSwitcherService : BaseUIScreenSwitcherService
{
    [SerializeField] private Button _mainScreenButton;
    [SerializeField] private Button _upgradeScreenButton;

    private void Start()
    {
        ShowMainScreen();
    }

    private void OnEnable()
    {
        _mainScreenButton.onClick.AddListener(ShowMainScreen);
        _upgradeScreenButton.onClick.AddListener(ShowUpgradeScreen);
    }

    private void OnDisable()
    {
        _mainScreenButton.onClick.RemoveListener(ShowMainScreen);
        _upgradeScreenButton.onClick.RemoveListener(ShowUpgradeScreen);
    }

    public override void ShowMainScreen()
    {
        mainScreenRoot.SetActive(true);
        upgradeScreenRoot.SetActive(false);
    }

    public override void ShowUpgradeScreen()
    {
        mainScreenRoot.SetActive(false);
        upgradeScreenRoot.SetActive(true);
    }
}
