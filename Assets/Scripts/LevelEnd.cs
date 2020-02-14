using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelEnd : MonoBehaviour {

	public string levelToLoad;

	public PlayerController thePlayer;
	public CameraController1 theCamera;
	public LevelManager theLevelManager;

	public float waitToMove;
	public float waitToLoad;
	private bool movePlayer;

	public GameObject pauseScreen;

	// Use this for initialization
	void Start () {

       
        

    }
	
    //IEnumerator FindPlayer()
    //{
    //    //yield return new WaitForSeconds(.25f);
    //  
    //
    //}
	// Update is called once per frame
	void Update () {
        thePlayer = FindObjectOfType<PlayerController>();
        if (movePlayer) 
		{
			thePlayer.myRigidBody.velocity = new Vector3 (thePlayer.moveSpeed, thePlayer.myRigidBody.velocity.y, 0f);
		}
	
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if(other.tag == "Player")
			{
				//SceneManager.LoadScene(levelToLoad);
			    StartCoroutine("LevelEndCo");
			}
	}

	public IEnumerator LevelEndCo()
	{
		thePlayer.canMove = false;
		theCamera.followTarget = false;
		//pauseScreen.SetActive (false);
		theLevelManager.invincible = true;
		thePlayer.myRigidBody.velocity = Vector3.zero;

		//PlayerPrefs.SetInt ("CoinCount", theLevelManager.coinCount);
		//PlayerPrefs.SetInt ("PlayerLives", theLevelManager.currentLives);
        PlayerPrefs.SetInt("GB", 2);

        theLevelManager.levelMusic.Stop ();
		theLevelManager.gameOverMusic.Play ();

		yield return new WaitForSeconds (waitToMove);
		movePlayer = true;

		yield return new WaitForSeconds (waitToLoad);
		SceneManager.LoadScene(levelToLoad);
	}
}
