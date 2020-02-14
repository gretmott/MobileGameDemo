using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour {

    private int character;
    public GameObject char1;
    public GameObject char2;
    public GameObject char3;

    // Use this for initialization
    void Start () {
		
        if (PlayerPrefs.HasKey ("character"))
        {
            character = PlayerPrefs.GetInt("character");
        }


        if (character == 0)
        {
            Instantiate (char1, this.transform.position, this.transform.rotation);
        }

        if (character == 1)
        {
            Instantiate(char2, this.transform.position, this.transform.rotation);
        }

        if(character == 2)
        {
            Instantiate(char3, this.transform.position, this.transform.rotation);
        }
    }

    
	
	// Update is called once per frame
	void Update () {
		
	}
}
