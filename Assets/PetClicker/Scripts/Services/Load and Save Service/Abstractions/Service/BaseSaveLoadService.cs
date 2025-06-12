

public abstract class BaseSaveLoadService
{
    public abstract void SaveData(BaseData data, string saveKey);

    public abstract BaseData LoadData(string saveKey);
}
