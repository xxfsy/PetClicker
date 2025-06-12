using Newtonsoft.Json;
using UnityEngine;

public class PlayerPrefsJsonSaveServise : BaseSaveLoadService
{
    private JsonSerializerSettings settings = new JsonSerializerSettings 
    {
        TypeNameHandling = TypeNameHandling.All
    };

    public static class SaveKeys
    {
        // ключи для типов дат, в будущем можно будет добавить еще ключей для других дат : BaseData
        public const string GameDataKey = "GameData";
    }

    public override void SaveData(BaseData data, string saveKey)
    {
        string json = JsonConvert.SerializeObject(data, settings);
        Debug.Log("save: " + json);

        PlayerPrefs.SetString(saveKey, json);

        PlayerPrefs.Save();
    }


    public override BaseData LoadData(string saveKey)
    {
        if (!PlayerPrefs.HasKey(saveKey))
        {
            switch (saveKey)
            {
                case SaveKeys.GameDataKey: return new GameData();
                default: return new BaseData();
            }
        }

        string json = PlayerPrefs.GetString(saveKey);
        Debug.Log("load: " + json);

        return JsonConvert.DeserializeObject<BaseData>(json, settings);
    }
}
