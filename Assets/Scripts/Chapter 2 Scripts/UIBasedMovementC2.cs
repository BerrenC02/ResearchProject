using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBasedMovementC2 : MonoBehaviour
{
    public float speed = 1;
    public float distance = 5;
    public float checkdistance = 0.4f;
    public LayerMask wallLayer;
    public LayerMask holeLayer;
    public bool Push = false;
    public Color[] colours;
    public GameObject Player;
    public GameObject PushParticle;
    private Vector3 dir;

    public AudioSource InvalidMove;
    public AudioSource ValidMove;
    public AudioSource ToggleOn;
    public AudioSource ToggleOff;

    public GameObject ToggleOnImage;
    public GameObject ToggleOffImage;

    private void Start()
    {
        PushParticle.SetActive(false);
        InvalidMove = GameObject.Find("MoveFail").GetComponent<AudioSource>();
        ValidMove = GameObject.Find("MoveSuccessCh2/3").GetComponent<AudioSource>();
        ToggleOn = GameObject.Find("ToggleCh2On").GetComponent<AudioSource>();
        ToggleOff = GameObject.Find("ToggleCh2Off").GetComponent<AudioSource>();

        ToggleOnImage = GameObject.Find("PushToggleOn");
        ToggleOffImage = GameObject.Find("PushToggleOff");

        ToggleOffImage.SetActive(false);
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
                    }
                    else if (holecheck[0].CompareTag("Hole"))
                    {
                        hits[0].transform.position = PushObjectNewPos;
                        transform.position = target;
                        ValidMove.PlayOneShot(ValidMove.clip);
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
            Player.GetComponent<Renderer>().material.color = colours[0];
            PushParticle.SetActive(false);
            ToggleOff.PlayOneShot(ToggleOff.clip);
            ToggleOnImage.SetActive(true);
            ToggleOffImage.SetActive(false);

        }
        if (Push == true)
        {
            Player.GetComponent<Renderer>().material.color = colours[1];
            PushParticle.SetActive(true);
            ToggleOn.PlayOneShot(ToggleOn.clip);
            ToggleOnImage.SetActive(false);
            ToggleOffImage.SetActive(true);
        }
    }
}


