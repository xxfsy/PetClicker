public abstract class BaseSaveLoadSrevice
{
    public abstract void SaveData<T>(T data, string saveKey) where T : BaseData;

    public abstract T LoadData<T>(string saveKey) where T : BaseData, new();
}
