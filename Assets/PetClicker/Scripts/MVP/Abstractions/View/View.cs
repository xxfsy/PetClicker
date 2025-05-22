using UnityEngine;

public abstract class View : MonoBehaviour
{
    protected Presenter _presenter;

    public void Initialize(Presenter presenter)
    {
        _presenter = presenter;
    }
}
