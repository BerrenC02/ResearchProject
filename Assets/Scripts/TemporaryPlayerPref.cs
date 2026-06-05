using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemporaryPlayerPref : MonoBehaviour
{
    public int number;
    public string prefname;
    // Start is called before the first frame update
    public void Press()
    {
        PlayerPrefs.SetInt((prefname), (number));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
