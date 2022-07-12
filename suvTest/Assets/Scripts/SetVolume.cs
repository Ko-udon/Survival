using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SetVolume : MonoBehaviour
{
    public AudioMixer mixer;
    public Slider slider;
    public string type;
    private float value;

    private void OnEnable()
    {
        switch(type)
        {
            case "BGM":
                mixer.GetFloat("BGMVolume", out value);
                break;

            case "FX":
                mixer.GetFloat("FXVolume", out value);
                break;
        }
        slider.value = value;
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void SetLevel(float sliderValue)
    {
        //mixer.SetFloat("BGMVolume", Mathf.Log10(sliderValue) * 20);
        switch (type)
        {
            case "BGM":
                mixer.SetFloat("BGMVolume", sliderValue);
                break;

            case "FX":
                mixer.SetFloat("FXVolume", sliderValue);
                break;
        }
        
    }
}
