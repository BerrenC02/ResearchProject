using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharCustomOption : MonoBehaviour
{
    public List<GameObject> FaceOptions;
    public int MaxFace;
    public TextMeshProUGUI Facetext;
    public int FacePos;

    public List<GameObject> HeadOptions;
    public int MaxHead;
    public TextMeshProUGUI Headtext;
    public int HeadPos;

    public AudioSource UISFX;

    private void Start()
    {
        
        FaceOptions = UnityEngine.Object.FindObjectsOfType<GameObject>(true).Where(obj => obj.CompareTag("FaceOptions")).OrderBy(obj => obj.name).ToList();
        foreach (GameObject obj in FaceOptions)
        {
            obj.SetActive(false);
            MaxFace++;
        }
        MaxFace--;
        FacePos = PlayerPrefs.GetInt("FaceOption");
        FaceOptions[FacePos].SetActive(true);
        Facetext.text = ("Option " + ((FacePos + 1).ToString()));

        HeadOptions = UnityEngine.Object.FindObjectsOfType<GameObject>(true).Where(obj => obj.CompareTag("HeadOptions")).OrderBy(obj => obj.name).ToList();
        foreach (GameObject obj in HeadOptions)
        {
            obj.SetActive(false);
            MaxHead++;
        }
        MaxHead--;
        HeadPos = PlayerPrefs.GetInt("HeadOption");
        HeadOptions[HeadPos].SetActive(true);
        Headtext.text = ("Option " + ((HeadPos + 1).ToString()));

        UISFX = GameObject.Find("UIButton").GetComponent<AudioSource>();
    }
    public void FaceLeftArrow()
    {
        Debug.Log(FacePos);
        if (FacePos == 0)
        {
            FaceOptions[FacePos].SetActive(false);
            FacePos = MaxFace;
            Debug.Log(FacePos);
            FaceOptions[FacePos].SetActive(true);
            Facetext.text = ("Option " + ((FacePos + 1).ToString()));
            Press();
        }
        else if (FacePos != 0)
        {
            FaceOptions[FacePos].SetActive(false);
            FacePos = FacePos - 1;
            FaceOptions[FacePos].SetActive(true);
            Debug.Log(FacePos);
            Facetext.text = ("Option " + ((FacePos + 1).ToString()));
            Press();
        }
    }
    public void FaceRightArrow()
    {
        Debug.Log(FacePos);
        if (FacePos == MaxFace)
        {
            FaceOptions[FacePos].SetActive(false);
            FacePos = 0;
            Debug.Log(FacePos);
            FaceOptions[FacePos].SetActive(true);
            Facetext.text = ("Option " + ((FacePos + 1).ToString()));
            Press();
        }
        else if (FacePos != MaxFace)
        {
            FaceOptions[FacePos].SetActive(false);
            FacePos = FacePos + 1;
            FaceOptions[FacePos].SetActive(true);
            Debug.Log(FacePos);
            Facetext.text = ("Option " + ((FacePos + 1).ToString()));
            Press();
        }
    }

    public void HeadLeftArrow()
    {
        if (HeadPos == 0)
        {
            HeadOptions[HeadPos].SetActive(false);
            HeadPos = MaxHead;
            Debug.Log(HeadPos);
            HeadOptions[HeadPos].SetActive(true);
            Headtext.text = ("Option " + ((HeadPos + 1).ToString()));
            Press();
        }
        else if (HeadPos != 0)
        {
            HeadOptions[HeadPos].SetActive(false);
            HeadPos = HeadPos - 1;
            HeadOptions[HeadPos].SetActive(true);
            Debug.Log(HeadPos);
            Headtext.text = ("Option " + ((HeadPos + 1).ToString()));
            Press();
        }
    }

    public void HeadRightArrow()
    {
        if (HeadPos == MaxHead)
        {
            HeadOptions[HeadPos].SetActive(false);
            HeadPos = 0;
            Debug.Log(HeadPos);
            HeadOptions[HeadPos].SetActive(true);
            Headtext.text = ("Option " + ((HeadPos + 1).ToString()));
            Press();
        }
        else if (HeadPos != MaxHead)
        {
            HeadOptions[HeadPos].SetActive(false);
            HeadPos = HeadPos + 1;
            HeadOptions[HeadPos].SetActive(true);
            Debug.Log(HeadPos);
            Headtext.text = ("Option " + ((HeadPos + 1).ToString()));
            Press();
        }
    }

    public void ExitScene()
    {
        PlayerPrefs.SetInt("HeadOption", (HeadPos));
        Debug.Log(HeadPos + "saved");
        PlayerPrefs.SetInt("FaceOption", (FacePos));
        Debug.Log(FacePos + "saved");
        PlayerPrefs.SetInt(("CharacterMade"), (1));
        PlayerPrefs.Save();

    }

    private void Press()
    {
        UISFX.PlayOneShot(UISFX.clip);
    }
}
