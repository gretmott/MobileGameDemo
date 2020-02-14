using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public GameObject target;
	private Vector3 targetPosition;

	public float followAhead;
	public float smoothing;

	public bool followTarget;
    public GameObject P1;
    public GameObject P2;

    public PlayerController PC1;
    public PlayerController PC2;
    public bool switched;

    // Use this for initialization
    void Start () {

        target = P1;
        switched = false;
		followTarget = true;
        StartCoroutine("FindPlayer");
	}

    IEnumerator FindPlayer()
    {
        yield return new WaitForSeconds(.25f);
        target = GameObject.FindGameObjectWithTag("Player");
    }
	
	// Update is called once per frame
	void Update () {

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

        if (switched == false)
        {
            target = P1;
            PC1.enabled = true;
            PC2.enabled = false;
        }

        if (switched == true)
        {
            target = P2;
            PC1.enabled = false;
            PC2.enabled = true;
        }

    }

    public void Switch()
    {
        if (switched == false)
        {
            switched = true;
        }

        else if (switched == true)
        {
            switched = false;
        }
    }
 
   
}
