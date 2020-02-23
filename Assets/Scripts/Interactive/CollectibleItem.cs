using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleItem : MonoBehaviour
{
    [SerializeField] private string itemName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other) 
    {
        Managers.Inventory.AddItem(itemName);
        Debug.Log("Item collected: " + itemName);
        Destroy(this.gameObject);
    }
}
