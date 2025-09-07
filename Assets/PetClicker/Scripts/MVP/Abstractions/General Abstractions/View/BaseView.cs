using UnityEngine;

public abstract class BaseView : MonoBehaviour
{
    protected BasePresenter presenter;

    public void Initialize(BasePresenter presenter)
    {
        this.presenter = presenter;
    }
}
