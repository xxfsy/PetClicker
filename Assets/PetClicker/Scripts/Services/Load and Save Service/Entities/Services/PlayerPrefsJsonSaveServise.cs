using UnityEngine;

public class PlayerPrefsJsonSaveServise : BaseSaveLoadSrevice
{
    public override void SaveData<T>(T data, string saveKey)
    {
        string json = JsonUtility.ToJson(data);

        PlayerPrefs.SetString(saveKey, json);

        PlayerPrefs.Save();
    }


    public override T LoadData<T>(string saveKey)
    {
        if (!PlayerPrefs.HasKey(saveKey))
        {
            return new T();
        }

        string json = PlayerPrefs.GetString(saveKey);

        return JsonUtility.FromJson<T>(json);
    }
}
