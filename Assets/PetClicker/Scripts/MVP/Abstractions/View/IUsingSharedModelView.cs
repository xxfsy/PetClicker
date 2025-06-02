public interface IUsingSharedModelView
{
    public void SetSharedModel(SharedModel sharedModel);

    public void SubscribeToModel();

    public void UnsubscribeFromModel();
}
