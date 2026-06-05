using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemporaryPlayerPref : MonoBehaviour
{
    //Most likely a temporary script, planning on adding this functionality to the NextTextButton script or Menu Script to reduce number of scripts
    public int number;
    public string prefname;
    public void Press()
    {
        PlayerPrefs.SetInt((prefname), (number));
    }
}
