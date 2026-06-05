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
    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject obj in Text)
        { 
            obj.SetActive(false);
            MaxDialouge++;
        }
        Text[0].SetActive(true);
    }

    // Update is called once per frame
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
