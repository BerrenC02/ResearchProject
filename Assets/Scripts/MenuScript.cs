using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    public string SceneName;
    public string ChapterPref;
    public AudioSource UISFX;
    public string TargetScene;
    private void Start()
    {
        if (SceneName == null)
        {
            SceneName = null; //Avoids having to enter a string in each scene
        }
        UISFX = GameObject.Find("UIButton").GetComponent<AudioSource>();
    }
    public void IntroductionSwitch()
    {
        TargetScene = "Introduction";
        StartCoroutine(UIButtonSFX());
    }
    public void Chapter1Switch()
    {
        TargetScene = "Chapter1Intro";
        StartCoroutine(UIButtonSFX());
    }
    public void Chapter2Switch()
    {
        TargetScene = "Chapter2Intro";
        StartCoroutine(UIButtonSFX());
    }
    public void Chapter3Switch()
    {
        TargetScene = "Chapter3Intro";
        StartCoroutine(UIButtonSFX());
    }
    public void PlayerPrefRest()
    {
        PlayerPrefs.DeleteKey("IntroductionComplete");
        PlayerPrefs.DeleteKey("Chapter1Complete");
        PlayerPrefs.DeleteKey("Chapter2Complete");
        PlayerPrefs.DeleteKey("Chapter3Complete");
        PlayerPrefs.DeleteKey("CharacterMade");
        SceneManager.LoadScene("ChapterSelector");
    }

    public void ChapterSelect()
    {
        TargetScene = "ChapterSelector";
        StartCoroutine(UIButtonSFX());
    }

    public void SceneMove() //For scenes that are visted once
    {
        TargetScene = SceneName;
        StartCoroutine(UIButtonSFX());
    }

    public void ResetScene()
    {
        TargetScene = SceneManager.GetActiveScene().name;
        StartCoroutine(UIButtonSFX());
    }

    public void ChapterTestCheat() //For testing purposes, will not be in used a final product
    {
        PlayerPrefs.SetInt(("IntroductionComplete"), (1));
        PlayerPrefs.SetInt(("Chapter1Complete"), (1));
        PlayerPrefs.SetInt(("Chapter2Complete"), (1));
        PlayerPrefs.SetInt(("Chapter3Complete"), (1));
        PlayerPrefs.SetInt(("CharacterMade"), (1));
        SceneManager.LoadScene("ChapterSelector");
    }

    public void ChapterFinishPref()
    {
        PlayerPrefs.SetInt((ChapterPref), (1));
    }

    public void SettingsScene()
    {
        TargetScene = "Settings";
        StartCoroutine(UIButtonSFX());
    }

    public void Chapter1Story()
    {
        TargetScene = "HonestWoodcutter";
        StartCoroutine(UIButtonSFX());
    }

    public void Chapter2Story()
    {
        TargetScene = "TheTortoiseandTheHare";
        StartCoroutine(UIButtonSFX());
    }
    public void Chapter3Story()
    {
        TargetScene = "TheBoyWhoCriedWolf";
        StartCoroutine(UIButtonSFX());
    }

    public void CharCustom()
    {
        TargetScene = "CustomChar";
        StartCoroutine(UIButtonSFX());
    }

    public void Exit()
    {
        Application.Quit();
        Debug.Log("Game Quit");
    }

    IEnumerator UIButtonSFX()
    {
        Lock();
        //Gets the length of the sound clip then plays the sound
        float duration = UISFX.clip.length;
        UISFX.PlayOneShot(UISFX.clip);
        //Starts to load scene in the background 
        AsyncOperation sceneLoading = SceneManager.LoadSceneAsync(TargetScene);
        //Stops the scene from loading by keeping it inactive
        sceneLoading.allowSceneActivation = false;
        //Pauses for duration of sound clip before moving to next line
        yield return new WaitForSeconds(duration);
        while (sceneLoading.progress < 0.9f) yield return null;
        sceneLoading.allowSceneActivation = true;
    }
    private void Lock() 
    {
        //Prevents multiple button presses while sound is playing
        //originally if button was pressed multiple times a scene would start loading
        //but only 1 would finish leaving the others, was worried this would cause issues
        //if done multiple times over a long session
        Button[] Buttons = FindObjectsOfType<Button>();
        foreach (UnityEngine.UI.Button obj in Buttons)
        {
            TMP_Text text = obj.GetComponentInChildren<TMP_Text>();
            if (text != null)
            {
                text.color = Color.red;
            }
            obj.interactable = false;
        }
    }
}
