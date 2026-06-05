using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TileFailCondition : MonoBehaviour
{
    public AudioSource Fail;

    private void Start()
    {
        Fail = GameObject.Find("FailAudio").GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Failed due to double step");
        other.gameObject.SetActive(false);
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
