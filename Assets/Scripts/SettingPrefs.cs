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
    public TMP_FontAsset AltFont;
    public TMP_FontAsset BasFont;
    public Button nextButton;
    public Button prevButton;

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
        toggle = !toggle;
        Debug.Log (toggle);
        if (toggle == false)
        {
            PlayerPrefs.SetFloat("ReadableFont", (0));
            PlayerPrefs.Save();

        }
        else
        {
            PlayerPrefs.SetFloat("ReadableFont", (1));
            PlayerPrefs.Save();
        }

        TMP_FontAsset fontToUse = toggle ? AltFont : BasFont;
        Debug.Log(fontToUse);

        TMP_Text[] texts = GameObject.FindObjectsOfType<TMP_Text>();
        foreach (TMP_Text txt in texts)
        {
            txt.font = fontToUse;
        }

    }
}
