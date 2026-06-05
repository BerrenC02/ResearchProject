using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTileMovement : MonoBehaviour
{
    public float speed;
    public float distance;
    public float checkdistance = 0.4f;
    public LayerMask wallLayer;
    public AudioSource Crash;

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

        //Allows movement as long as no objects on the wallLayer exist are in the way
        if (dir != Vector3.zero)
        {
            Vector3 target = transform.position + dir * distance;

            if (!Physics.CheckSphere(target, checkdistance, wallLayer))
            {
                transform.position = target;
            }
            else
            {
                Crash.Play();
            }
        }
    }
}
