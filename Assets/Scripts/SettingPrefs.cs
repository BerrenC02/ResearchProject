using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SettingPrefs : MonoBehaviour
{
    public Slider BackgroundSlider;
    public Slider SFXSlider;

    // Update is called once per frame
    void Start()
    {
        if (PlayerPrefs.HasKey("BackgroundVolumeValue"))
        {
            float savedVolume = PlayerPrefs.GetFloat("BackgroundVolumeValue", 0);
            BackgroundSlider.value = savedVolume;
            PlayerPrefs.Save(); //Saves the value
        }
        if (PlayerPrefs.HasKey("BackgroundVolumeValue"))
        {
            float savedVolume = PlayerPrefs.GetFloat("SFXVolumeValue", 0);
            SFXSlider.value = savedVolume;
            PlayerPrefs.Save(); //Saves the value
        }
    }

    public void BackgroundVolume()
    {
        PlayerPrefs.SetFloat("BackgroundVolumeValue", (BackgroundSlider.value));
        Debug.Log (BackgroundSlider.value);
        PlayerPrefs.Save();
    }
    public void SFXVolume()
    {
        PlayerPrefs.SetFloat("SFXVolumeValue", (SFXSlider.value));
        Debug.Log(SFXSlider.value);
        PlayerPrefs.Save();
    }


}
