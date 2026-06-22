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

        BackgroundVolume = PlayerPrefs.GetFloat("BackgroundVolumeValue");
        Debug.Log(BackgroundVolume);
        SFXVolume = PlayerPrefs.GetFloat("SFXVolumeValue");
        Debug.Log(SFXVolume);

        foreach (AudioSource obj in BackgroundAudio)
        {
            obj.GetComponent<AudioSource>().volume = BackgroundVolume;
        }
        foreach (AudioSource obj in SFXAudio)
        {
            obj.GetComponent<AudioSource>().volume = SFXVolume;
        }
    }
}
