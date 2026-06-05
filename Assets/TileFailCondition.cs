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
        //Gets the length of the sound clip then plays the sound
        float failduration = Fail.clip.length;
        Fail.PlayOneShot(Fail.clip);

        //Starts to load scene in the background 
        AsyncOperation sceneLoading = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
        //Stops the scene from loading by keeping it inactive
        sceneLoading.allowSceneActivation = false;

        //Pauses for duration of sound clip before moving to next line
        yield return new WaitForSeconds(failduration);

        while (sceneLoading.progress < 0.9f) yield return null;

        sceneLoading.allowSceneActivation = true;
    }
}
