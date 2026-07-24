using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FontChange : MonoBehaviour
{
    private bool Active;
    public TMP_FontAsset AltFont;
    
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("ReadableFont"))
        {
            float ChangeFontPref = PlayerPrefs.GetFloat("ReadableFont");
            Debug.Log(ChangeFontPref);
            if (ChangeFontPref == 0)
            {
                Active = false;
            }
            else
            {
                Active = true;
            }
        }
        if (Active == true)
        {
            TMP_Text[] texts = GameObject.FindObjectsOfType<TMP_Text>();
            Debug.Log(texts);
            foreach (TMP_Text txt in texts)
            {
                txt.font = AltFont;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
