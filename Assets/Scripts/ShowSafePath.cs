using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShowSafePath : MonoBehaviour
{
    public List<GameObject> SafePath;
    public GameObject Player;

    private void Start()
    {
        Player.SetActive(false);
        //Saves having to manually add each tile to a list in engine
        SafePath = UnityEngine.Object.FindObjectsOfType<GameObject>().Where(obj => obj.CompareTag("SafePath")).ToList();
        StartCoroutine(HoleDealy());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator HoleDealy()
    {
        yield return new WaitForSeconds(5);
        foreach (GameObject obj in SafePath)
        {
            obj.SetActive(false);
        }
        Player.SetActive(true);
    }
}
