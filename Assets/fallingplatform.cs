using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallingplatform : MonoBehaviour {


    public Rigidbody2D rb2D;
    public float waittime;
  
    
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            StartCoroutine("Fall");
        }
    }

    public IEnumerator Fall ()
    {
        yield return new WaitForSeconds(waittime);
        rb2D.isKinematic = false;

        yield return new WaitForSeconds(1.5f);
        this.gameObject.SetActive(false);
    }
}
