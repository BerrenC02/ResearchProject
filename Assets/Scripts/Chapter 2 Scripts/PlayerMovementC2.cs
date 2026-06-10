using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementC2 : MonoBehaviour
{
    public float speed;
    public float distance;
    public float checkdistance = 0.4f;
    public LayerMask wallLayer;
    public LayerMask holeLayer;
    public AudioSource Crash;
    public bool Push = false;
    public Color[] colours;
    public GameObject Player;
    public GameObject PushParticle;

    private void Start()
    {
        PushParticle.SetActive(false);
    }
    void Update()
    {
        Vector3 dir = Vector3.zero;

        if (Input.GetKeyDown(KeyCode.W))
        {
            dir = Vector3.forward;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            dir = Vector3.back;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            dir = Vector3.left;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            dir = Vector3.right;
        }
        else if (Input.GetKeyDown(KeyCode.E))
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

        //Allows movement as long as no objects on the wallLayer exist are in the way
        if (dir != Vector3.zero)
        {
            Vector3 target = transform.position + dir * distance;

            Collider[] hits = Physics.OverlapSphere(target, checkdistance, wallLayer);
            Collider[] hits2 = Physics.OverlapSphere(target, checkdistance, holeLayer);

            if (hits.Length == 0 && hits2.Length == 0)
            {
                transform.position = target;
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
                }
                else
                {
                    Crash.Play();
                }
            }
            else
            {
                Crash.Play();
            }
            
        }
    }
}


