using UnityEngine;
using System.Collections;

public class CameraController1 : MonoBehaviour {

	public GameObject target;
	private Vector3 targetPosition;

	public float followAhead;
	public float smoothing;

	public bool followTarget;
  


    // Use this for initialization
    void Start () {

        
    }


	
	// Update is called once per frame
	void Update () {

        target = GameObject.FindGameObjectWithTag("Player");

        if (followTarget) 
		{
			
			targetPosition = new Vector3 (target.transform.position.x, transform.position.y, transform.position.z);

			if (target.transform.localScale.x > 0f) {
				targetPosition = new Vector3 (targetPosition.x + followAhead, targetPosition.y, targetPosition.z);
			} else {
				targetPosition = new Vector3 (targetPosition.x - followAhead, targetPosition.y, targetPosition.z);
			}

			//transform.position = targetPosition;

			transform.position = Vector3.Lerp (transform.position, targetPosition, smoothing * Time.deltaTime);
		}

     

    }

 
   
}
