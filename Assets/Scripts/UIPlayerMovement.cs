using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPlayerMovement : MonoBehaviour
{
    public float speed = 1;
    public float distance = 5;
    public float checkdistance = 0.4f;
    public LayerMask wallLayer;
    public AudioSource Crash;
    private Vector3 dir;

    void Update()
    {
        //Allows movement as long as no objects on the wallLayer exist are in the way
        if (dir != Vector3.zero)
        {
            Vector3 target = transform.position + dir * distance;

            if (!Physics.CheckSphere(target, checkdistance, wallLayer))
            {
                transform.position = target;
                dir = Vector3.zero;
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
}
