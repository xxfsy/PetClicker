using System.Collections.Generic;
using UnityEngine;

public abstract class BaseSaveLoadManager : MonoBehaviour
{
    protected List<ISaveableController> saveableControllers;

    protected List<ISaveableLayer> saveableSharedModels;

    public void Initialize(List<ISaveableController> saveableControllers, List<ISaveableLayer> saveableSharedModels)
    {
        this.saveableControllers = saveableControllers;
        this.saveableSharedModels = saveableSharedModels;
    }

    //// добавить абстрактные или обычные методы (?) SaveGame() и LoadGame()
    //protected void SaveGame()
    //{
    //    foreach (ISaveableController saveableController in saveableControllers)
    //    {
    //        saveableController.SaveLayers();
    //    }

    //    foreach (ISaveableLayer saveableSharedModel in saveableSharedModels)
    //    {
    //        saveableSharedModel.SaveLayer();
    //    }
    //}

    //protected void LoadGame()
    //{
    //    foreach (ISaveableController saveableController in saveableControllers)
    //    {
    //        saveableController.LoadLayers();
    //    }

    //    foreach (ISaveableLayer saveableSharedModel in saveableSharedModels)
    //    {
    //        saveableSharedModel.LoadLayer();
    //    }
    //}
}
