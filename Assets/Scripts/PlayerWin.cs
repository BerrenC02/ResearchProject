using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerWin : MonoBehaviour
{

    public GameObject Target;
    public AudioSource Solved;
    public AudioSource Fail;
    public string NextScene;

    private void Start()
    {

    }

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.SetActive(false);
            Debug.Log("Solved");
            StartCoroutine(WinSound());
        }
    }

    IEnumerator WinSound()
    {
        float solveduration = Solved.clip.length;
        Solved.PlayOneShot(Solved.clip);
        AsyncOperation sceneLoading = SceneManager.LoadSceneAsync(NextScene);
        sceneLoading.allowSceneActivation = false;
        yield return new WaitForSeconds(solveduration);
        while (sceneLoading.progress < 0.9f) yield return null;
        sceneLoading.allowSceneActivation = true;
    }

}
