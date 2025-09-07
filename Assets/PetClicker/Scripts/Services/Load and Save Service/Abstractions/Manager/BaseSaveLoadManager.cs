using System.Collections.Generic;
using UnityEngine;

public abstract class BaseSaveLoadManager : MonoBehaviour
{
    // каждый менеджер работает только через один сервис и с одним типом даты. 

    protected List<BaseSaveableController> saveableControllers;

    protected List<BaseSaveableModel> saveableSharedModels;

    protected BaseSaveLoadService saveLoadService;

    protected string saveKey;

    protected BaseData data;

    public virtual void Initialize(List<BaseSaveableController> saveableControllers, List<BaseSaveableModel> saveableSharedModels, BaseSaveLoadService saveLoadService, string saveKey)
    {
        this.saveableControllers = saveableControllers;
        this.saveableSharedModels = saveableSharedModels;
        this.saveLoadService = saveLoadService;
        this.saveKey = saveKey;
    }

    protected virtual void SaveGame()
    {
        foreach (BaseSaveableController saveableController in saveableControllers)
        {
            saveableController?.SaveLayers(data);
        }

        foreach (BaseSaveableModel saveableSharedModel in saveableSharedModels)
        {
            saveableSharedModel?.SaveLayer(data);
        }

        saveLoadService.SaveData(data, saveKey);
    }

    protected virtual void LoadGame()
    {
        data = saveLoadService.LoadData(saveKey);

        foreach (BaseSaveableController saveableController in saveableControllers)
        {
            saveableController?.LoadLayers(data);
        }

        foreach (BaseSaveableModel saveableSharedModel in saveableSharedModels)
        {
            saveableSharedModel?.LoadLayer(data);
        }
    }
}
