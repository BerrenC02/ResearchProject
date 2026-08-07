using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillHole : MonoBehaviour
{
    public GameObject self;
    public AudioSource HoleFill;
    public GameObject HoleFillPrefab;

    private void Start()
    {
        HoleFill = GameObject.Find("HoleFill").GetComponent<AudioSource>();
    }
    void OnCollisionEnter(UnityEngine.Collision collision)
    {

        if (collision.gameObject.CompareTag("Pushable"))
        {
            Instantiate(HoleFillPrefab, transform.position, transform.rotation);
            HoleFill.PlayOneShot(HoleFill.clip);
            collision.gameObject.SetActive(false);
            self.SetActive(false);
        }
    }
}
