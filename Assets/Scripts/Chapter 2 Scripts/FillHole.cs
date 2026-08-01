using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillHole : MonoBehaviour
{
    public GameObject self;
    public AudioSource HoleFill;

    private void Start()
    {
        HoleFill = GameObject.Find("HoleFill").GetComponent<AudioSource>();
    }
    void OnCollisionEnter(UnityEngine.Collision collision)
    {

        if (collision.gameObject.CompareTag("Pushable"))
        {
            collision.gameObject.SetActive(false);
            self.SetActive(false);
            HoleFill.PlayOneShot(HoleFill.clip);
        }
    }
}
