using System.Collections.Generic;

public class SaveLoadManager : BaseSaveLoadManager
{
    public override void Initialize(List<ISaveableMVPController> saveableControllers, List<ISaveableMVPLayer> saveableSharedModels, BaseSaveLoadService saveLoadService, string saveKey)
    {
        base.Initialize(saveableControllers, saveableSharedModels, saveLoadService, saveKey);

        LoadGame();
    }

    private void OnApplicationPause(bool pause)
    {
        if (pause)
            SaveGame();
    }

#if UNITY_EDITOR
    private void OnApplicationQuit()
    {
        SaveGame();
    }
#endif
}
