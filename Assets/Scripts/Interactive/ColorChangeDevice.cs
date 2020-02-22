﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class ColorChangeDevice : MonoBehaviour
{
    private Renderer renderer;
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Operate() {
        Color random = new Color(Random.Range(0f, 1f),
                        Random.Range(0f,1f), Random.Range(0f,1f));
        // Color origin = GetComponent<Renderer>().material.color;
        // GetComponent<Renderer>().material.color = Color.Lerp( origin, random, 1 );
        DOTween.To( 
            () => renderer.material.color, 
            toColor => renderer.material.color = toColor,
            random, 1f);
    }
}
