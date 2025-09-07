using UnityEngine;

public abstract class BaseUIScreenSwitcherService : MonoBehaviour
{
    // Здесь будут все экраны игры. При появлении новых экранов надо будет добавлять поля и методы для них
    protected GameObject mainScreenRoot;
    protected GameObject upgradeScreenRoot;

    public virtual void Initialize(GameObject mainScreenRoot, GameObject upgradeScreenRoot)
    {
        this.mainScreenRoot = mainScreenRoot;
        this.upgradeScreenRoot = upgradeScreenRoot;
    }

    // Абстрактные методы для экранов

    public abstract void ShowMainScreen();

    public abstract void ShowUpgradeScreen();
}
