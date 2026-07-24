using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharCustomColour : MonoBehaviour
{
    public List<GameObject> FaceOptions;
    public int FacePos;

    public List<GameObject> HeadOptions;
    public int HeadPos;

    public List<Color> FaceColors;
    public int MaxFaceColors;
    public int FaceColourPos;
    public TextMeshProUGUI FaceColourText;

    public List<Color> HeadColors;
    public int MaxHeadColors;
    public int HeadColourPos;
    public TextMeshProUGUI HeadColourText;

    private void Start()
    {
        FaceOptions = UnityEngine.Object.FindObjectsOfType<GameObject>(true).Where(obj => obj.CompareTag("FaceOptions")).OrderBy(obj => obj.name).ToList();
        FaceColourPos = PlayerPrefs.GetInt("FaceColourOption");

        foreach (Color obj in FaceColors)
        {

            MaxFaceColors++;
        }

        foreach (GameObject obj in FaceOptions)
        {
            obj.SetActive(false);

            Image img = obj.GetComponentInChildren<Image>(true);
            Debug.Log(img);
            if (img != null)
            {
                img.color = FaceColors[FaceColourPos];
            }
        }
        FacePos = PlayerPrefs.GetInt("FaceOption");
        FaceOptions[FacePos].SetActive(true);
        MaxFaceColors--;

        FaceColourText.text = ("Option " + ((FaceColourPos + 1).ToString()));


        HeadOptions = UnityEngine.Object.FindObjectsOfType<GameObject>(true).Where(obj => obj.CompareTag("HeadOptions")).OrderBy(obj => obj.name).ToList();
        HeadColourPos = PlayerPrefs.GetInt("HeadColourOption");

        foreach (Color obj in HeadColors)
        {

            MaxHeadColors++;
        }

        foreach (GameObject obj in HeadOptions)
        {
            obj.SetActive(false);

            Image img = obj.GetComponentInChildren<Image>(true);
            Debug.Log(img);
            if (img != null)
            {
                img.color = HeadColors[HeadColourPos];
            }
        }
        HeadPos = PlayerPrefs.GetInt("HeadOption");
        HeadOptions[HeadPos].SetActive(true);
        MaxHeadColors--;

        HeadColourText.text = ("Option " + ((HeadColourPos + 1).ToString()));


    }
    public void FaceLeftArrow()
    {
        if (FaceColourPos == 0)
        {
            FaceColourPos = MaxFaceColors;
            foreach (GameObject obj in FaceOptions)
            {
                Image img = obj.GetComponentInChildren<Image>(true);
                Debug.Log(img);
                if (img != null)
                {
                    img.color = FaceColors[FaceColourPos];
                }
            }
            FaceColourText.text = ("Option " + ((FaceColourPos + 1).ToString()));
        }
        else if (FaceColourPos != 0)
        {
            FaceColourPos--;
            foreach (GameObject obj in FaceOptions)
            {
                Image img = obj.GetComponentInChildren<Image>(true);
                Debug.Log(img);
                if (img != null)
                {
                    img.color = FaceColors[FaceColourPos];
                }
            }
            FaceColourText.text = ("Option " + ((FaceColourPos + 1).ToString()));
        }
    }
    public void FaceRightArrow()
    {
        if (FaceColourPos == MaxFaceColors)
        {
            FaceColourPos = 0;
            foreach (GameObject obj in FaceOptions)
            {
                Image img = obj.GetComponentInChildren<Image>(true);
                Debug.Log(img);
                if (img != null)
                {
                    img.color = FaceColors[FaceColourPos];
                }
            }
            FaceColourText.text = ("Option " + ((FaceColourPos + 1).ToString()));
        }
        else if (FaceColourPos != MaxFaceColors)
        {
            FaceColourPos++;
            foreach (GameObject obj in FaceOptions)
            {
                Image img = obj.GetComponentInChildren<Image>(true);
                Debug.Log(img);
                if (img != null)
                {
                    img.color = FaceColors[FaceColourPos];
                }
            }
            FaceColourText.text = ("Option " + ((FaceColourPos + 1).ToString()));
        }
    }

    public void HeadLeftArrow()
    {
        if (HeadColourPos == 0)
        {
            HeadColourPos = MaxHeadColors;
            foreach (GameObject obj in HeadOptions)
            {
                Image img = obj.GetComponentInChildren<Image>(true);
                Debug.Log(img);
                if (img != null)
                {
                    img.color = HeadColors[HeadColourPos];
                }
            }
            HeadColourText.text = ("Option " + ((HeadColourPos + 1).ToString()));
        }
        else if (HeadColourPos != 0)
        {
            HeadColourPos--;
            foreach (GameObject obj in HeadOptions)
            {
                Image img = obj.GetComponentInChildren<Image>(true);
                Debug.Log(img);
                if (img != null)
                {
                    img.color = HeadColors[HeadColourPos];
                }
            }
            HeadColourText.text = ("Option " + ((HeadColourPos + 1).ToString()));
        }
    }

    public void HeadRightArrow()
    {
        if (HeadColourPos == MaxHeadColors)
        {
            HeadColourPos = 0;
            foreach (GameObject obj in HeadOptions)
            {
                Image img = obj.GetComponentInChildren<Image>(true);
                Debug.Log(img);
                if (img != null)
                {
                    img.color = HeadColors[HeadColourPos];
                }
            }
            HeadColourText.text = ("Option " + ((HeadColourPos + 1).ToString()));
        }
        else if (HeadColourPos != MaxHeadColors)
        {
            HeadColourPos++;
            foreach (GameObject obj in HeadOptions)
            {
                Image img = obj.GetComponentInChildren<Image>(true);
                Debug.Log(img);
                if (img != null)
                {
                    img.color = HeadColors[HeadColourPos];
                }
            }
            HeadColourText.text = ("Option " + ((HeadColourPos + 1).ToString()));
        }
    }

    public void ExitScene()
    {
        PlayerPrefs.SetInt("HeadColourOption", (HeadColourPos));
        Debug.Log(HeadPos + "saved");
        PlayerPrefs.SetInt("FaceColourOption", (FaceColourPos));
        Debug.Log(FacePos + "saved");
        PlayerPrefs.Save();

    }
}
