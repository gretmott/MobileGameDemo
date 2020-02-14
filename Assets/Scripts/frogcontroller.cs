using UnityEngine;
using System.Collections;

public class frogcontroller : MonoBehaviour {

	public float moveSpeed;
	private bool canMove;

	private Rigidbody2D myRigidbody;

	// Use this for initialization

	//void Awake ()
	//{
	//	StartCoroutine (Kill());
	//}

	void Start () {

		myRigidbody = GetComponent<Rigidbody2D> ();
	
	}
	
	// Update is called once per frame
	void Update () {

		if (canMove) 
		{
			myRigidbody.velocity = new Vector3 (-moveSpeed, myRigidbody.velocity.y, 0f);
		}
	
	}

	void OnEnable()
	{
		canMove = false;
	}

	void OnBecameVisible()
	{
		canMove = true;
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "KillPlane") 
		{
			gameObject.SetActive (false);
		}
	}

	//IEnumerator Kill ()
	//{
	//	yield return new WaitForSeconds (5f);
	//	Destroy (gameObject);
	//}

}
