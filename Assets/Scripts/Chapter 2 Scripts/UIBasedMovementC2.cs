using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIBasedMovementC2 : MonoBehaviour
{
    public float speed = 1;
    public float distance = 5;
    public float checkdistance = 0.4f;
    public LayerMask wallLayer;
    public LayerMask holeLayer;
    public bool Push = false;

    public GameObject Player;
    public GameObject PushParticle;
    private Vector3 dir;

    public AudioSource InvalidMove;
    public AudioSource ValidMove;
    public AudioSource ToggleOn;
    public AudioSource ToggleOff;
    public AudioSource PushRock;

    public GameObject ToggleOnImage;
    public GameObject ToggleOffImage;

    public AudioSource UISFX;
    private string TargetScene;

    private void Start()
    {
        PushParticle.SetActive(false);
        InvalidMove = GameObject.Find("MoveFail").GetComponent<AudioSource>();
        ValidMove = GameObject.Find("MoveSuccessCh2/3").GetComponent<AudioSource>();
        ToggleOn = GameObject.Find("ToggleCh2On").GetComponent<AudioSource>();
        ToggleOff = GameObject.Find("ToggleCh2Off").GetComponent<AudioSource>();
        PushRock = GameObject.Find("PushRock").GetComponent<AudioSource>();

        ToggleOnImage = GameObject.Find("PushToggleOn");
        ToggleOffImage = GameObject.Find("PushToggleOff");

        ToggleOffImage.SetActive(false);

        UISFX = GameObject.Find("UIButton").GetComponent<AudioSource>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            UpArrow();
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            UpArrow();
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            DownArrow();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            DownArrow();
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            LeftArrow();
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            LeftArrow();
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            RightArrow();
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            RightArrow();
        }
        else if(Input.GetKeyDown(KeyCode.E))
        {
            Toggle();
        }

        //Allows movement as long as no objects on the wallLayer exist are in the way
        if (dir != Vector3.zero)
        {
            Vector3 target = transform.position + dir * distance;

            Collider[] hits = Physics.OverlapSphere(target, checkdistance, wallLayer);
            Collider[] hits2 = Physics.OverlapSphere(target, checkdistance, holeLayer);

            if (hits.Length == 0 && hits2.Length == 0)
            {
                transform.position = target;
                dir = Vector3.zero;
                ValidMove.PlayOneShot(ValidMove.clip);
                return;
            }
            else if (hits.Length > 0 && hits[0].CompareTag("Pushable") && Push == true)
            {
                Vector3 PushObjectNewPos = hits[0].transform.position + dir * distance;
                if (!Physics.CheckSphere(PushObjectNewPos, checkdistance, wallLayer))
                {
                    Collider[] holecheck = Physics.OverlapSphere(PushObjectNewPos, checkdistance);
                    if (holecheck.Length == 0)
                    {
                        hits[0].transform.position = PushObjectNewPos;
                        transform.position = target;
                        ValidMove.PlayOneShot(ValidMove.clip);
                        PushRock.PlayOneShot(PushRock.clip);
                    }
                    else if (holecheck[0].CompareTag("Hole"))
                    {
                        hits[0].transform.position = PushObjectNewPos;
                        transform.position = target;
                        ValidMove.PlayOneShot(ValidMove.clip);
                        PushRock.PlayOneShot(PushRock.clip);
                    }
                    dir = Vector3.zero;
                }
                else
                {
                    InvalidMove.PlayOneShot(InvalidMove.clip);
                    dir = Vector3.zero;
                }
            }
            else
            {
                InvalidMove.PlayOneShot(InvalidMove.clip);
                dir = Vector3.zero;
            }
            
        }
    }
    public void UpArrow()
    {
        dir = Vector3.forward;
        Debug.Log("Up Pressed");
    }
    public void DownArrow()
    {
        dir = Vector3.back;
        Debug.Log("Down Pressed");
    }
    public void LeftArrow()
    {
        dir = Vector3.left;
        Debug.Log("Left Pressed");
    }
    public void RightArrow()
    {
        dir = Vector3.right;
        Debug.Log("Right Pressed");
    }
    public void Toggle()
    {
        Push = !Push;
        if (Push == false)
        {
            PushParticle.SetActive(false);
            ToggleOff.PlayOneShot(ToggleOff.clip);
            ToggleOnImage.SetActive(true);
            ToggleOffImage.SetActive(false);

        }
        if (Push == true)
        {
            PushParticle.SetActive(true);
            ToggleOn.PlayOneShot(ToggleOn.clip);
            ToggleOnImage.SetActive(false);
            ToggleOffImage.SetActive(true);
        }
    }

    public void ResetScene()
    {
        TargetScene = SceneManager.GetActiveScene().name;
        StartCoroutine(UIButtonSFX());
    }

    IEnumerator UIButtonSFX()
    {
        Lock();
        //Gets the length of the sound clip then plays the sound
        float duration = UISFX.clip.length;
        UISFX.PlayOneShot(UISFX.clip);
        //Starts to load scene in the background 
        AsyncOperation sceneLoading = SceneManager.LoadSceneAsync(TargetScene);
        //Stops the scene from loading by keeping it inactive
        sceneLoading.allowSceneActivation = false;
        //Pauses for duration of sound clip before moving to next line
        yield return new WaitForSeconds(duration);
        while (sceneLoading.progress < 0.9f) yield return null;
        sceneLoading.allowSceneActivation = true;
    }

    private void Lock()
    {
        //Prevents multiple button presses while sound is playing
        //originally if button was pressed multiple times a scene would start loading
        //but only 1 would finish leaving the others, was worried this would cause issues
        //if done multiple times over a long session
        Button[] Buttons = FindObjectsOfType<Button>();
        foreach (UnityEngine.UI.Button obj in Buttons)
        {
            TMP_Text text = obj.GetComponentInChildren<TMP_Text>();
            if (text != null)
            {
                text.color = Color.red;
            }
            obj.interactable = false;
        }
    }
}


