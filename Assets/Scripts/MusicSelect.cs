using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using TMPro;
using UnityEngine;

public class MusicSelect : MonoBehaviour
{
    public List<AudioSource> BackgroundAudio;
    public List<AudioSource> SFXAudio;
    public int MaxBG;
    public int BGPos;
    public float BackgroundVolume;
    public float SFXVolume;
    public AudioSource UISFX;


    public static MusicSelect Instance;

    private void Awake()
    {
        if (Instance != this && Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        else
        {

        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        if (PlayerPrefs.HasKey("BGTrack"))
        {
            BGPos = PlayerPrefs.GetInt("BGTrack");
        }
        else
        {
            BGPos = 0;
        }
        Debug.Log(BGPos);
        foreach (AudioSource obj in BackgroundAudio)
        {
            MaxBG++;
        }
        MaxBG--;
        BackgroundAudio[BGPos].Play();
        UISFX = GameObject.Find("UIButton").GetComponent<AudioSource>();
        SFXAudio = UnityEngine.Object.FindObjectsOfType<AudioSource>().Where(obj => obj.CompareTag("SFXAudio")).ToList();
    }

    public void Update()
    {
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
        foreach (AudioSource obj in SFXAudio)
        {
            obj.GetComponent<AudioSource>().volume = SFXVolume;
        }
    }
    public void FaceRightArrow()
    {
        if (BGPos == MaxBG)
        {
            BackgroundAudio[BGPos].Stop();
            BGPos = 0;
            Debug.Log(BGPos);
            BackgroundAudio[BGPos].Play();
            PlayerPrefs.SetInt("BGTrack", (BGPos));
            PlayerPrefs.Save();
            UISFX.PlayOneShot(UISFX.clip);
        }
        else if (BGPos != MaxBG)
        {
            BackgroundAudio[BGPos].Stop();
            BGPos = BGPos + 1;
            Debug.Log(BGPos);
            BackgroundAudio[BGPos].Play();
            PlayerPrefs.SetInt("BGTrack", (BGPos));
            PlayerPrefs.Save();
            UISFX.PlayOneShot(UISFX.clip);

        }
    }

    public void HeadLeftArrow()
    {
        if (BGPos == 0)
        {
            BackgroundAudio[BGPos].Stop();
            BGPos = MaxBG;
            Debug.Log(BGPos);
            BackgroundAudio[BGPos].Play();
            PlayerPrefs.SetInt("BGTrack", (BGPos));
            PlayerPrefs.Save();
            UISFX.PlayOneShot(UISFX.clip);

        }
        else if (BGPos != 0)
        {
            BackgroundAudio[BGPos].Stop();
            BGPos = BGPos - 1;
            Debug.Log((BGPos));
            BackgroundAudio[BGPos].Play();
            PlayerPrefs.SetInt("BGTrack", (BGPos));
            PlayerPrefs.Save();
            UISFX.PlayOneShot(UISFX.clip);

        }
    }
}
