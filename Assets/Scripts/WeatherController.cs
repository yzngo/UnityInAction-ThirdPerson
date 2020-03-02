﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherController : MonoBehaviour
{
    [SerializeField] private Material sky;
    [SerializeField] private Light sun;
    private float _fullIntensity;
    private float _cloudValue = 0f;
    private bool darker = true;
    void Awake() 
    {
        Messenger.AddListener(GameEvent.WEATHER_UPDATED, OnWeatherUpdated);
    }
    void OnDestroy() {
        Messenger.RemoveListener(GameEvent.WEATHER_UPDATED, OnWeatherUpdated);
    }
    // Start is called before the first frame update
    void Start()
    {
        _fullIntensity = sun.intensity;
    }

    // Update is called once per frame
    void Update()
    {
        // SetOvercast(_cloudValue);
        // if (darker == true) {
        //     _cloudValue += .001f;
        //     if (_cloudValue >= 1.0f ) {
        //         darker = false;
        //     }
        // } else {
        //     _cloudValue -= .001f;
        //     if (_cloudValue <= 0.0f ) {
        //         darker = true;
        //     }
        // }
    }
    private void OnWeatherUpdated()
    {
        SetOvercast(Managers.Weather.cloudValue);
    }

    private void SetOvercast(float value)
    {
        sky.SetFloat("_Blend", value);
        sun.intensity = _fullIntensity - (_fullIntensity * value);
    }
}
