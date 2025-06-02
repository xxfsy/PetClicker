using UnityEngine;

public abstract class BaseView : MonoBehaviour // мб удалить или оставить монобех ведь вью будет работать с UI unity?
{
    protected BasePresenter _presenter;

    public void Initialize(BasePresenter presenter)
    {
        _presenter = presenter;
    }
}
