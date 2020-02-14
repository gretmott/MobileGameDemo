using UnityEngine;
using System.Collections;

public class ResetOnRespawn : MonoBehaviour {

	private Vector3 startPosition;
	private Quaternion startRotation;
	private Vector3 startLocalScale;

	private Rigidbody2D myRigidbody;
    public Rigidbody2D rb2D;


    // Use this for initialization
    void Start () {
       
        startPosition = transform.position;
		startRotation = transform.rotation;
		startLocalScale = transform.localScale;

		if (GetComponent<Rigidbody2D> () != null) 
		{
			myRigidbody = GetComponent<Rigidbody2D> ();
		}

        if(this.gameObject.tag == "FP")
        {
            rb2D = GetComponent<Rigidbody2D>();
        }

	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ResetObject()
	{
		transform.position = startPosition;
		transform.rotation = startRotation;
		transform.localScale = startLocalScale;

		if (myRigidbody != null) 
		{
			myRigidbody.velocity = Vector3.zero;
		}

        if (rb2D != null)
        {
            rb2D.isKinematic = true;
        }
	}
}
