using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TileFailCondition : MonoBehaviour
{
    public AudioSource Fail;
    public float SFXVolume;
    public bool Chapter1;
    public bool Chapter3;

    private void Start()
    {
        if (Chapter1 == true)
        {
            Fail = GameObject.Find("PuzzleFailCh1").GetComponent<AudioSource>();
        }
        else if (Chapter3 == true)
        {
            Fail = GameObject.Find("PuzzleFailCh3").GetComponent<AudioSource>();
        }
        SFXVolume = PlayerPrefs.GetFloat("SFXVolumeValue");
        Debug.Log(SFXVolume);
        Fail.volume = SFXVolume;
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Failed due to double step");
        UIPlayerMovement playermovescript = other.GetComponentInChildren<UIPlayerMovement>();
        playermovescript.enabled = false;
        StartCoroutine(FailSound());
    }

    IEnumerator FailSound()
    {
        float failduration = Fail.clip.length;
        Fail.PlayOneShot(Fail.clip);
        AsyncOperation sceneLoading = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
        sceneLoading.allowSceneActivation = false;
        yield return new WaitForSeconds(failduration);
        while (sceneLoading.progress < 0.9f) yield return null;
        sceneLoading.allowSceneActivation = true;
    }
}
