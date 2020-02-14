using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Duck : MonoBehaviour {

    public Animator myanim;
    public PlayerController pc;

	// Use this for initialization
	void Start () {
        pc = FindObjectOfType<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Small()
    {
        transform.localScale = new Vector3(.5f, .5f, .5f);
        pc.shrunk = true;
        pc.moveSpeed = 10f;
        //myanim.SetBool("Duck", true);
    }

    public void Big()
    {
        transform.localScale = new Vector3(1f, 1f, 1f);
        pc.shrunk = false;
        pc.moveSpeed = 5f;
        //myanim.SetBool("Duck", false);
    }


}
