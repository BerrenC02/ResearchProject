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
        //Not really needed as can be played without a keyboard but is more comfortable for the web build.
        //While both Onscreen Button and Keyboard press can be done at once it doesn't break anything as far as I can tell
        //so will leave it as a speedy way to get through game for those confident enough in their abilities

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
