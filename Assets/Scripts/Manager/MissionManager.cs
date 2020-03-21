﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MissionManager : MonoBehaviour, IGameManager
{
    public ManagerStatus status {get; private set;}

    public int curLevel {get; private set;}
    public int maxLevel {get; private set;}
    private NetworkService _network;

    public void Startup(NetworkService service)
    {
        Debug.Log("Mission manager starting...");
        _network = service;
        curLevel = 0;
        maxLevel = 1;
        status = ManagerStatus.Started;
    }

    public void GoToNext()
    {
        if (curLevel < maxLevel) {
            curLevel++;
            string name = "Level" + curLevel;
            Debug.Log("Loading" + name);
            SceneManager.LoadScene(name);
        } else {
            Debug.Log("Last level");
        }
    }
}
