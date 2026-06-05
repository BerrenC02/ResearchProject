using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OneStepTiles : MonoBehaviour
{
    public List <GameObject> PuzzleTiles;
    public GameObject Target;
    public AudioSource Solved;
    public AudioSource Fail;
    public string NextScene;

    private void Start()
    {
        //Saves having to manually add each tile to a list in engine
        PuzzleTiles = UnityEngine.Object.FindObjectsOfType<GameObject>().Where(obj => obj.CompareTag("PuzzleTile")).ToList();
    }

    void OnTriggerEnter(Collider other)
    {
        //Removes the visited tiles from the list upon reaching the goal
        PuzzleTiles.RemoveAll(obj => obj == null || !obj.activeInHierarchy);

        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Triggered");
            int RemainingTile = PuzzleTiles.Count;
            if (RemainingTile == 0) //Only activates when all tiles have been visited
            {
                other.gameObject.SetActive(false);
                Debug.Log("Solved");
                StartCoroutine(WinSound());
            }
            else
            {
                other.gameObject.SetActive(false);
                Debug.Log("Failed");
                StartCoroutine(FailSound());
            }
        }
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

    IEnumerator WinSound()
    {
        float solveduration = Solved.clip.length;
        Fail.PlayOneShot(Solved.clip);
        AsyncOperation sceneLoading = SceneManager.LoadSceneAsync(NextScene);
        sceneLoading.allowSceneActivation = false;
        yield return new WaitForSeconds(solveduration);
        while (sceneLoading.progress < 0.9f) yield return null;
        sceneLoading.allowSceneActivation = true;
    }

}
