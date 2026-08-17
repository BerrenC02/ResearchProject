using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FontChange : MonoBehaviour
{
    private bool Active;
    public TMP_FontAsset AltFont;
    public List<TMP_Text> TMP_Texts;
    public TMP_FontAsset TextFont;
    public bool Settings;
    private GameObject[] textObjects;

    // Start is called before the first frame update


    void Start()
    {
        if (PlayerPrefs.HasKey("ReadableFont"))
        {
            float ChangeFontPref = PlayerPrefs.GetInt("ReadableFont");
            
            if (ChangeFontPref == 0)
            {
                Active = false;
            }
            else if (ChangeFontPref == 1)
            {
                Active = true;
            }
            Debug.Log("alt font " + Active);
        }
        else
        {
            Active = false;
        }
        if (Active == true)
        {

            TMP_Text[] texts = GetComponentsInChildren<TMP_Text>(true);
            Debug.Log(TMP_Texts);
            foreach (TMP_Text txt in texts)
            {
                txt.font = AltFont;
            }
        }
        if (Settings != true)
        {
            TextFont = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Settings == true)
        {
            if (PlayerPrefs.HasKey("ReadableFont"))
            {
                float ChangeFontPref = PlayerPrefs.GetInt("ReadableFont");

                if (ChangeFontPref == 0)
                {
                    Active = false;
                }
                else if (ChangeFontPref == 1)
                {
                    Active = true;
                }
                Debug.Log("alt font " + Active);
            }

            if (Active == true)
            {
                Debug.Log(TMP_Texts);
                foreach (TMP_Text txt in TMP_Texts)
                {
                    txt.font = AltFont;
                }
            }
            else if (Active == false)
            {
                foreach (TMP_Text txt in TMP_Texts)
                {
                    txt.font = TextFont;
                }
            }
        }
    }
}
