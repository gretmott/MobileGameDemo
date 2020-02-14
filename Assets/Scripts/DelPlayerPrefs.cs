using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelPlayerPrefs : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        PlayerPrefs.DeleteAll();
    }

   
}
