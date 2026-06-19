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
    public AudioSource Crash;
    public bool Push = false;
    public Color[] colours;
    public GameObject Player;
    public GameObject PushParticle;
    private Vector3 dir;

    private void Start()
    {
        PushParticle.SetActive(false);
    }
    void Update()
    {
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
                    }
                    else if (holecheck[0].CompareTag("Hole"))
                    {
                        hits[0].transform.position = PushObjectNewPos;
                        transform.position = target;
                    }
                    dir = Vector3.zero;
                }
                else
                {
                    Crash.Play();
                    dir = Vector3.zero;
                }
            }
            else
            {
                Crash.Play();
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
        }
        if (Push == true)
        {
            Player.GetComponent<Renderer>().material.color = colours[1];
            PushParticle.SetActive(true);
        }
    }
}


