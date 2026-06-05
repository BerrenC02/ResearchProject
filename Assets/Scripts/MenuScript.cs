using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public string SceneName;

    private void Start()
    {
        if (SceneName == null)
        {
            SceneName = null;
        }
    }
    public void IntroductionSwitch()
    {
        SceneManager.LoadScene("Introduction");
    }
    public void Chapter1Switch()
    {
        SceneManager.LoadScene("TilePuzzleTest");
    }
    public void Chapter2Switch()
    {
        SceneManager.LoadScene("Chapter2");
    }
    public void PlayerPrefRest()
    {
        PlayerPrefs.DeleteAll(); //Might need to be reworked in the future if PlayerPrefs are used elsewhere, fine as a temporary solution
        SceneManager.LoadScene("ChapterSelector");
    }

    public void TilePuzzletest()
    {
        SceneManager.LoadScene("TilePuzzleTest");
    }

    public void ChapterSelect()
    {
        SceneManager.LoadScene("ChapterSelector");
    }

    public void SceneMove() //For scenes that are visted once
    {
        SceneManager.LoadScene(SceneName);
    }
}
