using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileDestroySelf : MonoBehaviour
{
    public GameObject FailTile;

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Triggered");
            Instantiate(FailTile, transform.position, transform.rotation);
            gameObject.SetActive(false);
        }
    }
}
