using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointTrigger : MonoBehaviour
{
    public string identifier;
    private bool _triggered;
    void OnTriggerEnter(Collider other)
    {
        if (_triggered) {
            return;
        }
        Managers.Weather.LogWeather(identifier);
        _triggered = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
