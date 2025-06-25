using System.Collections.Generic;
using UnityEngine;

public abstract class BaseSaveLoadManager : MonoBehaviour
{
    // каждый менеджер работает только через один сервис и с одним типом даты

    protected List<ISaveableMVPController> saveableControllers;

    protected List<ISaveableModel> saveableSharedModels;

    protected BaseSaveLoadService saveLoadService;

    protected string saveKey;

    protected BaseData data;

    public virtual void Initialize(List<ISaveableMVPController> saveableControllers, List<ISaveableModel> saveableSharedModels, BaseSaveLoadService saveLoadService, string saveKey)
    {
        this.saveableControllers = saveableControllers;
        this.saveableSharedModels = saveableSharedModels;
        this.saveLoadService = saveLoadService;
        this.saveKey = saveKey;
    }

    protected virtual void SaveGame()
    {
        foreach (ISaveableMVPController saveableController in saveableControllers)
        {
            saveableController?.SaveLayers(data);
        }

        foreach (ISaveableModel saveableSharedModel in saveableSharedModels)
        {
            saveableSharedModel?.SaveLayer(data);
        }

        saveLoadService.SaveData(data, saveKey);
    }

    protected virtual void LoadGame()
    {
        data = saveLoadService.LoadData(saveKey);

        foreach (ISaveableMVPController saveableController in saveableControllers)
        {
            saveableController?.LoadLayers(data);
        }

        foreach (ISaveableModel saveableSharedModel in saveableSharedModels)
        {
            saveableSharedModel?.LoadLayer(data);
        }
    }
}
