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

    void Start()
    {
        foreach (GameObject obj in Text)
        { 
            obj.SetActive(false);
            MaxDialouge++;
        }
        Text[0].SetActive(true);
    }


    public void ButtonPressed()
    {
        Text[CurrentDialouge].SetActive(false);
        CurrentDialouge++;
        if (CurrentDialouge <= MaxDialouge)
        {
            Text[CurrentDialouge].SetActive(true);
        }
        else
        {
            Debug.Log("End of Dialouge");
        }


    }
}
