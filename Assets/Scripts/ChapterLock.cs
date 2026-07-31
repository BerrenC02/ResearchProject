using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;
using TMPro;

public class ChapterLock : MonoBehaviour
{
    public Button[] Buttons;
    public Color col;

    void Start()
    {
        col.a = 0;
        foreach (UnityEngine.UI.Button obj in Buttons)
        {
            //Only doing this in script instead of in engine to avoid me forgetting to do one of the buttons and having to rebuild
            ColorBlock cb = obj.colors;
            cb.normalColor = col;
            cb.highlightedColor = col;
            cb.pressedColor = col;
            cb.disabledColor = col;
            cb.colorMultiplier = 1f;
            obj.colors = cb;

            obj.interactable = false;
            TMP_Text text = obj.GetComponentInChildren<TMP_Text>();
            if (text != null)
            {
                text.color = Color.red;
            }
        }
        Buttons[13].interactable = true;
        Buttons[13].GetComponentInChildren<TMP_Text>().color = Color.black;
        Buttons[14].interactable = true;
        Buttons[14].GetComponentInChildren<TMP_Text>().color = Color.black;
        Buttons[15].interactable = true;
        Buttons[15].GetComponentInChildren<TMP_Text>().color = Color.black;
        Buttons[16].interactable = true;
        Buttons[16].GetComponentInChildren<TMP_Text>().color = Color.black;
        Buttons[17].interactable = true;
        Buttons[17].GetComponentInChildren<TMP_Text>().color = Color.black;
        Buttons[18].interactable = true;
        Buttons[18].GetComponentInChildren<TMP_Text>().color = Color.black;

        if (PlayerPrefs.HasKey("CharacterMade"))
        {
            Buttons[0].interactable = true;
            Buttons[0].GetComponentInChildren<TMP_Text>().color = Color.black;
        }
        
        if (PlayerPrefs.HasKey("IntroductionComplete"))
        {
            Buttons[1].interactable = true;
            Buttons[1].GetComponentInChildren<TMP_Text>().color = Color.black;
        }

        if (PlayerPrefs.HasKey("Chapter1Complete"))
        {
            Buttons[2].interactable = true;
            Buttons[2].GetComponentInChildren<TMP_Text>().color = Color.black;
            Buttons[3].interactable = true;
            Buttons[3].GetComponentInChildren<TMP_Text>().color = Color.black;
        }

        if (PlayerPrefs.HasKey("Chapter2Complete"))
        {
            Buttons[4].interactable = true;
            Buttons[4].GetComponentInChildren<TMP_Text>().color = Color.black;
            Buttons[5].interactable = true;
            Buttons[5].GetComponentInChildren<TMP_Text>().color = Color.black;
        }

        if (PlayerPrefs.HasKey("Chapter3Complete"))
        {
            Buttons[6].interactable = true;
            Buttons[6].GetComponentInChildren<TMP_Text>().color = Color.black;
            //Buttons[7].interactable = true;
            //Buttons[7].GetComponentInChildren<TMP_Text>().color = Color.black;
        }
    }
}
