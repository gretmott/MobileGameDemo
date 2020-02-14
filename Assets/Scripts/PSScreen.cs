using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PSScreen : MonoBehaviour {

    public string leveltoLoad;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LevelLoad()
    {
        SceneManager.LoadScene(leveltoLoad);
    }
}
