using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerWin : MonoBehaviour
{

    public GameObject Target;
    public AudioSource PuzzleSuccess;
    public string NextScene;

    private void Start()
    {
        PuzzleSuccess = GameObject.Find("PuzzleSuccess").GetComponent<AudioSource>();
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
        float solveduration = PuzzleSuccess.clip.length;
        PuzzleSuccess.PlayOneShot(PuzzleSuccess.clip);
        AsyncOperation sceneLoading = SceneManager.LoadSceneAsync(NextScene);
        sceneLoading.allowSceneActivation = false;
        yield return new WaitForSeconds(solveduration);
        while (sceneLoading.progress < 0.9f) yield return null;
        sceneLoading.allowSceneActivation = true;
    }

}
