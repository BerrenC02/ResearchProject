using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillHole : MonoBehaviour
{
    public GameObject self;
    void OnCollisionEnter(UnityEngine.Collision collision)
    {

        if (collision.gameObject.CompareTag("Pushable"))
        {
            collision.gameObject.SetActive(false);
            self.SetActive(false);
        }
    }
}
