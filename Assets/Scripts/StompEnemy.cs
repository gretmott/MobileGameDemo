using UnityEngine;
using System.Collections;

public class StompEnemy : MonoBehaviour {

	public GameObject Dieburst;

	private Rigidbody2D playerRigidbody;
	public float bounceForce;

	// Use this for initialization
	void Start () {

		playerRigidbody = transform.parent.GetComponent<Rigidbody2D>();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Enemy") 
		{
			other.gameObject.SetActive (false);
			Instantiate (Dieburst, other.transform.position, other.transform.rotation);
			playerRigidbody.velocity = new Vector3 (playerRigidbody.velocity.x, bounceForce, 0f);
		}
	}	
}
