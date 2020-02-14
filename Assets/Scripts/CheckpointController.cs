using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CheckpointController : MonoBehaviour {

	public Sprite flagclosed;
	public Sprite flagopen;

	private SpriteRenderer mysprite;
	public bool checkpointActive;
	public GameObject player;

	// Use this for initialization
	void Start () {

		mysprite = GetComponent<SpriteRenderer> ();
	
	}
	
	// Update is called once per frame
	void Update () {

	
	}

	void OnTriggerEnter2D (Collider2D other)
	{

		if (other.tag == "Player") 
		{
			mysprite.sprite = flagopen;
			checkpointActive = true;
			//PlayerPrefs.SetFloat("PlayerX", player.transform.position.x);
			//PlayerPrefs.SetFloat("PlayerY", player.transform.position.y);
			//PlayerPrefs.SetFloat("PlayerZ", player.transform.position.z);

		}
	}
		
}
