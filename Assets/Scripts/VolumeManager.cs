using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class VolumeManager : MonoBehaviour
{
    public List<AudioSource> BackgroundAudio;
    public List<AudioSource> SFXAudio;
    public float BackgroundVolume;
    public float SFXVolume;

    // Start is called before the first frame update
    
    void Start()
    {

        BackgroundAudio = UnityEngine.Object.FindObjectsOfType<AudioSource>().Where(obj => obj.CompareTag("BackgroundAudio")).ToList();
        SFXAudio = UnityEngine.Object.FindObjectsOfType<AudioSource>().Where(obj => obj.CompareTag("SFXAudio")).ToList();

        if (PlayerPrefs.HasKey("BackgroundVolumeValue"))
        {
            BackgroundVolume = PlayerPrefs.GetFloat("BackgroundVolumeValue");
        }
        else
        {
            BackgroundVolume = 0.5f;
        }
        Debug.Log(BackgroundVolume);

        foreach (AudioSource obj in BackgroundAudio)
        {
            obj.GetComponent<AudioSource>().volume = BackgroundVolume;
        }

        if (PlayerPrefs.HasKey("SFXVolumeValue"))
        {
            SFXVolume = PlayerPrefs.GetFloat("SFXVolumeValue");
        }
        else
        {
            SFXVolume = 0.5f;
        }
        Debug.Log(SFXVolume);

        foreach (AudioSource obj in SFXAudio)
        {
            obj.GetComponent<AudioSource>().volume = SFXVolume;
        }
    }
}
