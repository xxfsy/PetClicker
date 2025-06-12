using Newtonsoft.Json;
using UnityEngine;

public class PlayerPrefsJsonSaveServise : BaseSaveLoadService
{
    private JsonSerializerSettings settings = new JsonSerializerSettings
    {
        TypeNameHandling = TypeNameHandling.Auto
    };

    public static class SaveKeys
    {
        // ключи для типов дат, в будущем можно будет добавить еще ключей для других дат : BaseData
        public const string GameDataKey = "GameData";
    }

    public override void SaveData(BaseData data, string saveKey)
    {
        string json = JsonConvert.SerializeObject(data, settings);

        PlayerPrefs.SetString(saveKey, json);

        PlayerPrefs.Save();
    }


    public override BaseData LoadData(string saveKey)
    {
        if (!PlayerPrefs.HasKey(saveKey))
        {
            return null;
        }

        string json = PlayerPrefs.GetString(saveKey);

        return JsonConvert.DeserializeObject<BaseData>(json, settings);
    }
}
