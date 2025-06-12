using System.Collections.Generic;

public class SaveLoadController : BaseSaveLoadController
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

    private void OnApplicationQuit()
    {
        SaveGame();
    }
}
