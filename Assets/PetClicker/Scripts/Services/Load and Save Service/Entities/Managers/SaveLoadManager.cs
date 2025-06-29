﻿using System.Collections.Generic;
using UnityEngine;

public class SaveLoadManager : BaseSaveLoadManager, ITickable
{
    public float TickCooldownInSeconds { get; private set; }

    private float _timerToCooldownTick;

    public override void Initialize(List<ISaveableMVPController> saveableControllers, List<ISaveableModel> saveableSharedModels, BaseSaveLoadService saveLoadService, string saveKey)
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

    public void SetTickCooldown(float tickCooldownInSeconds)
    {
        TickCooldownInSeconds = tickCooldownInSeconds;
    }

    public void Tick(float timeFromLastTick)
    {
        _timerToCooldownTick += timeFromLastTick;

        if (_timerToCooldownTick >= TickCooldownInSeconds)
        {
            _timerToCooldownTick = 0;
            SaveGame();
        }
    }
}
