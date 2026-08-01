using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextTextButton : MonoBehaviour
{
    public GameObject[] Text;
    public int CurrentDialouge;
    public int MaxDialouge;
    public AudioSource UISFX;


    void Start()
    {
        foreach (GameObject obj in Text)
        { 
            obj.SetActive(false);
            MaxDialouge++;
        }
        Text[0].SetActive(true);
        UISFX = GameObject.Find("UIButton").GetComponent<AudioSource>();
    }


    public void ButtonPressed()
    {
        Text[CurrentDialouge].SetActive(false);
        CurrentDialouge++;
        if (CurrentDialouge <= MaxDialouge)
        {
            Text[CurrentDialouge].SetActive(true);
            UISFX.PlayOneShot(UISFX.clip);
        }
        else
        {
            Debug.Log("End of Dialouge");
        }


    }
}
