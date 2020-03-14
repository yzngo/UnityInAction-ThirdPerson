﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SettingsPopup : MonoBehaviour
{
    [SerializeField] private AudioClip sound;
    [SerializeField] private Slider speedSlider;
    // Start is called before the first frame update
    void Start()
    {
        speedSlider.value = PlayerPrefs.GetFloat("speed", 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Open() {
        gameObject.SetActive( true );
    }
    public void Close() {
        gameObject.SetActive( false );
    }

    public void OnSubmitName(string name) {
        Debug.Log(name);
    }
    public void OnSpeedValue(float speed) {
        // Messenger<float>.Broadcast(GameEvent.SPEED_CHANGED, speed);
        PlayerPrefs.SetFloat("speed", speed);
    }
    public void OnSoundToggle()
    {
        Managers.Audio.soundMute = !Managers.Audio.soundMute;
        Managers.Audio.PlaySound(clip: sound);
    }
    public void OnSoundValue(float volume) => Managers.Audio.soundVolume = volume;
}