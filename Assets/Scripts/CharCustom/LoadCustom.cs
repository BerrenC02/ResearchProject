using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadCustom : MonoBehaviour
{
    public List<GameObject> FaceOptions;
    public int FacePos = 0;

    public List<GameObject> HeadOptions;
    public int HeadPos = 0;

    public List<Color> FaceColors;
    public int MaxFaceColors;
    public int FaceColourPos;

    public List<Color> HeadColors;
    public int MaxHeadColors;
    public int HeadColourPos;
    // Start is called before the first frame update
    void Start()
    {
        FaceOptions = UnityEngine.Object.FindObjectsOfType<GameObject>().Where(obj => obj.CompareTag("FaceOptions")).OrderBy(obj => obj.name).ToList();
        foreach (GameObject obj in FaceOptions)
        {
            obj.SetActive(false);
        }
        
        //Checks Face options, if does not exist set to 0
        if (PlayerPrefs.HasKey("FaceOption"))
        {
            FacePos = PlayerPrefs.GetInt("FaceOption");
        }
        else
        {
            FacePos = 0;
        }
        FaceOptions[FacePos].SetActive(true);

        HeadOptions = UnityEngine.Object.FindObjectsOfType<GameObject>().Where(obj => obj.CompareTag("HeadOptions")).OrderBy(obj => obj.name).ToList();
        foreach (GameObject obj in HeadOptions)
        {
            obj.SetActive(false);

        }

        //Check Head options, if does not exist set to 0
        if (PlayerPrefs.HasKey("HeadOption"))
        {
            HeadPos = PlayerPrefs.GetInt("HeadOption");
        }
        else
        {
            HeadPos = 0;
        }
        HeadOptions[HeadPos].SetActive(true);

        foreach (Color obj in FaceColors)
        {

            MaxFaceColors++;
        }
        MaxFaceColors--;
        
        //Check Face Colour, if does not exist set to 0
        if (PlayerPrefs.HasKey("FaceColourOption"))
        {
            FaceColourPos = PlayerPrefs.GetInt("FaceColourOption");
        }
        else
        {
            FaceColourPos = 0;
        }
            
        foreach (GameObject obj in FaceOptions)
        {
            Image img = obj.GetComponentInChildren<Image>(true);
            if (img != null)
            {
                img.color = FaceColors[FaceColourPos];
            }
        }

        foreach (Color obj in HeadColors)
        {

            MaxHeadColors++;
        }
        MaxHeadColors--;

        //Check Head Colour, if does not exist set to 0
        if (PlayerPrefs.HasKey("HeadColourOption"))
        {
            FaceColourPos = PlayerPrefs.GetInt("HeadColourOption");
        }
        else
        {
            FaceColourPos = 0;
        }

        foreach (GameObject obj in HeadOptions)
        {
            Image img = obj.GetComponentInChildren<Image>(true);
            if (img != null)
            {
                img.color = HeadColors[HeadColourPos];
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
