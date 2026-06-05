using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
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
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("ChapterSelector");
    }

    public void TilePuzzletest()
    {
        SceneManager.LoadScene("TilePuzzleTest");
    }
}
