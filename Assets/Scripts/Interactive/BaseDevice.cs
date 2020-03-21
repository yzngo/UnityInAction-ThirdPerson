﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseDevice : MonoBehaviour
{
    public float radius = 3.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown() 
    {
        Transform player = GameObject.FindWithTag("Player").transform;
        if (Vector3.Distance(player.position, transform.position) < radius) {
            Vector3 direction = transform.position - player.position;
            if (Vector3.Dot(player.forward, direction) > .5f) {
                Operate();
            }
        }
    }
    public virtual void Operate()
    {
    }
}
