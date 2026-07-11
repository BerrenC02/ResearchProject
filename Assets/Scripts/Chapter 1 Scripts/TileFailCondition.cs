using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TileFailCondition : MonoBehaviour
{
    public AudioSource Fail;
    public float SFXVolume;

    private void Start()
    {
        Fail = GameObject.Find("FailAudio").GetComponent<AudioSource>();

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
