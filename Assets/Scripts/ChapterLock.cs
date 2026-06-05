using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

public class ChapterLock : MonoBehaviour
{
    public Button[] Buttons;

    void Start()
    {

        foreach (UnityEngine.UI.Button obj in Buttons)
        {

            ColorBlock cb = obj.colors;
            cb.normalColor = Color.white;
            cb.highlightedColor = Color.gray;
            cb.pressedColor = Color.green;
            cb.disabledColor = Color.red;
            cb.colorMultiplier = 1f;
            obj.colors = cb;

            obj.interactable = false;
        }
        Buttons[0].interactable = true;

        if (PlayerPrefs.HasKey("IntroductionComplete"))
        {
            Buttons[1].interactable = true;
        }

        if (PlayerPrefs.HasKey("Chapter1Complete"))
        {
            Buttons[2].interactable = true;
        }
    }
}
