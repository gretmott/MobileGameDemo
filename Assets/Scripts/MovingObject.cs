using UnityEngine;
using System.Collections;

public class MovingObject : MonoBehaviour {

	public GameObject objectToMove;

	public Transform startPoint;
	public Transform endPoint;

	public float moveSpeed;

	private Vector3 currentTarget;

	// Use this for initialization
	void Start () {

		currentTarget = endPoint.position;
	
	}
	
	// Update is called once per frame
	void Update () {

		objectToMove.transform.position = Vector3.MoveTowards (objectToMove.transform.position, currentTarget, moveSpeed * Time.deltaTime);

		if (Mathf.Approximately(objectToMove.transform.position.x, endPoint.position.x)) 
		{
			currentTarget = startPoint.position;
		}

		if (Mathf.Approximately(objectToMove.transform.position .x, startPoint.position.x)) 
		{
			currentTarget = endPoint.position;
		}
	
	}
}
