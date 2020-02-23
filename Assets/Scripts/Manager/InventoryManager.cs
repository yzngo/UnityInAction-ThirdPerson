using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour, IGameManager
{
    // property can be read from anywhere but only set within this script
    public ManagerStatus status { get; private set; }

    public void Startup() 
    {
        Debug.Log("Inventory manager starting...");
        status = ManagerStatus.Started;
    }
}
