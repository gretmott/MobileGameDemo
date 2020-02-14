using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : MonoBehaviour {

    public GameObject objectToMove;
    public float moveSpeed;
    private Vector3 currentTarget;
    public bool playertarget;
    public GameObject player;
    public Transform playert;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (playertarget == true)
        {
            currentTarget = new Vector2(player.transform.position.x, player.transform.position.y);
            transform.right = transform.position - playert.position;
            objectToMove.transform.position = Vector3.MoveTowards(objectToMove.transform.position, currentTarget, moveSpeed * Time.deltaTime);
        }


        if (player.transform.position.x > objectToMove.transform.position.x) 
        {
            transform.localScale = new Vector2(1, -1);
        }

        else
        {
            transform.localScale = new Vector2(1, 1);
        }
	}
}
