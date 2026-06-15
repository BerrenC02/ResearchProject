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
            SceneName = null; //Avoids having to enter a string in each scene
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
        SceneManager.LoadScene("PushPuzzleTest 1");
    }
    public void Chapter3Switch()
    {
        SceneManager.LoadScene("PathPuzzleTest 1");
    }
    public void PlayerPrefRest()
    {
        PlayerPrefs.DeleteAll(); //Might need to be reworked in the future if PlayerPrefs are used elsewhere, fine as a temporary solution
        SceneManager.LoadScene("ChapterSelector");
    }

    public void ChapterSelect()
    {
        SceneManager.LoadScene("ChapterSelector");
    }

    public void SceneMove() //For scenes that are visted once
    {
        SceneManager.LoadScene(SceneName);
    }

    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    public void ChapterTestCheat() //For testing purposes, will not be in used a final product
    {
        PlayerPrefs.SetInt(("IntroductionComplete"), (1));
        PlayerPrefs.SetInt(("Chapter1Complete"), (1));
        PlayerPrefs.SetInt(("Chapter2Complete"), (1));
        PlayerPrefs.SetInt(("Chapter3Complete"), (1));
        SceneManager.LoadScene("ChapterSelector");
    }
}
