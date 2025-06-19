using System.Collections.Generic;

public abstract class BaseSharedModel
{
    protected List<IUsingSharedModelView> views = new List<IUsingSharedModelView>();

    //public void Initialize(List<IUsingSharedModelView> views)
    //{
    //    this.views = views;
    //}

    public void AddNewView(IUsingSharedModelView newView)
    {
        views.Add(newView);
    }
}
