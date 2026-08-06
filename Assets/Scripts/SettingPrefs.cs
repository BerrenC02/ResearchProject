using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SettingPrefs : MonoBehaviour
{
    public Slider BackgroundSlider;
    public Slider SFXSlider;
    public bool toggle;
    public Button nextButton;
    public Button prevButton;
    public AudioSource UISFX;

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
        nextButton.onClick.AddListener(() => MusicSelect.Instance.FaceRightArrow());
        prevButton.onClick.AddListener(() => MusicSelect.Instance.HeadLeftArrow());

        UISFX = GameObject.Find("UIButton").GetComponent<AudioSource>();
        float toggletemp = PlayerPrefs.GetInt("ReadableFont", 0);
        if (toggletemp == 0)
        {
            toggle = false;
        }
        else if (toggletemp == 1)
        {
            toggle = true;
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
    public void Font()
    {
        Debug.Log("pressed");
        if (toggle == false)
        {
            toggle = true;
        }
        else if (toggle == true) 
        {
            toggle = false;
        }
        Debug.Log (toggle);
        if (toggle == false)
        {
            PlayerPrefs.SetInt("ReadableFont", (0));
            PlayerPrefs.Save();

        }
        else if (toggle == true)
        {
            PlayerPrefs.SetInt("ReadableFont", (1));
            PlayerPrefs.Save();
        }

    }
}
