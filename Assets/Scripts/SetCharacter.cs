using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetCharacter : MonoBehaviour {

    public Button greenbird;
    public int gb;

	// Use this for initialization
	void Start () {

        if (PlayerPrefs.HasKey("GB"))
        {
            gb = PlayerPrefs.GetInt("GB");
        }

        if (gb == 2)
        {
            greenbird.interactable = true;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void yellow()
    {
        PlayerPrefs.SetInt("character", 0);
    }

    public void red()
    {
        PlayerPrefs.SetInt("character", 1);
    }

    public void green ()
    {
        PlayerPrefs.SetInt("character", 2);
    }
}
