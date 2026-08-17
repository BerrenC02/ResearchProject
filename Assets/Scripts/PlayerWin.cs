using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerWin : MonoBehaviour
{

    public GameObject Target;
    public AudioSource PuzzleSuccess;
    public List<string> NextScene;
    public GameObject UIControls;

    private void Start()
    {
        PuzzleSuccess = GameObject.Find("PuzzleSuccess").GetComponent<AudioSource>();
        UIControls = GameObject.Find("PlayerControls(Ch2) Variant");
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.SetActive(false);
            if (UIControls == null)
            {
                UIControls = GameObject.Find("PlayerControls");
            }
            Debug.Log("Solved");
            if (UIControls != null)
            {
                UIControls.SetActive(false);
            }
            StartCoroutine(WinSound());
        }
    }

    IEnumerator WinSound()
    {
        string TargetScene = NextScene[Random.Range(0, NextScene.Count)];
        float solveduration = PuzzleSuccess.clip.length;
        PuzzleSuccess.PlayOneShot(PuzzleSuccess.clip);
        AsyncOperation sceneLoading = SceneManager.LoadSceneAsync(TargetScene);
        sceneLoading.allowSceneActivation = false;
        yield return new WaitForSeconds(solveduration);
        while (sceneLoading.progress < 0.9f) yield return null;
        sceneLoading.allowSceneActivation = true;
    }

}
