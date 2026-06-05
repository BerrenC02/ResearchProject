using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTileMovement : MonoBehaviour
{
    public float speed; //How fast the player moves, public allows it to be edited directly in unity
    public float distance;
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

        if (dir != Vector3.zero)
        {
            Vector3 target = transform.position + dir * distance;

            if (!Physics.CheckSphere(target, 0.4f, wallLayer))
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
