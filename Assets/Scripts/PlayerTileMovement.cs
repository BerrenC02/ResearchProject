using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTileMovement : MonoBehaviour
{
    public float speed;
    public float distance;
    public float checkdistance = 0.4f;
    public LayerMask wallLayer;
    public AudioSource InvalidMove;
    public AudioSource ValidMove;
    private Vector3 dir;
    public bool Chapter1;
    public bool Chapter3;

    private void Start()
    {
        if (Chapter1 == true)
        {
            ValidMove = GameObject.Find("MoveSuccessCh1").GetComponent<AudioSource>();
        }
        else if (Chapter3 == false)
        {
            ValidMove = GameObject.Find("MoveSuccessCh2/3").GetComponent<AudioSource>();
        }
        InvalidMove = GameObject.Find("MoveFail").GetComponent<AudioSource>();
    }
    void Update()
    {
        dir = Vector3.zero;

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

        //Allows movement as long as no objects on the wallLayer exist are in the way
        if (dir != Vector3.zero)
        {
            Vector3 target = transform.position + dir * distance;

            if (!Physics.CheckSphere(target, checkdistance, wallLayer))
            {
                transform.position = target;
                ValidMove.PlayOneShot(ValidMove.clip);
            }
            else
            {
                InvalidMove.PlayOneShot(InvalidMove.clip);
            }
        }
    }
}
