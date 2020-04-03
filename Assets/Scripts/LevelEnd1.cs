using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelEnd1 : MonoBehaviour {

	public string levelToLoad;

	public PlayerController thePlayer;
	public Rigidbody2D myRB;
	public CameraController theCamera;
	public LevelManager theLevelManager;

	public float waitToMove;
	public float waitToLoad;
	private bool movePlayer;

	public GameObject pauseScreen;

	public bool tutorial;

	public int score;
	public bool levelOver;

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
			//thePlayer.myRB2d.velocity = new Vector3 (thePlayer.moveSpeed, thePlayer.myRB2d.velocity.y, 0f);
		}

        if (score >= 2 && levelOver == false)
            //change this number later ^
        {
			levelOver = true;
			StartCoroutine("LevelEndcCo");
            if (tutorial == true)
            {
				PlayerPrefs.SetInt("LvlStart", 1);
            }
        }
	
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if(other.tag == "Player")
			{
				//SceneManager.LoadScene(levelToLoad);
			    StartCoroutine("LevelEndCo");
			}


		if (tutorial == true)
		{
			PlayerPrefs.SetInt("LvlStart", 1);
		}
	}


	public IEnumerator LevelEndCo()
	{
		//thePlayer.canMove = false;
		//theCamera.followTarget = false;
		//pauseScreen.SetActive (false);
		theLevelManager.invincible = true;
		thePlayer.myRB2d.velocity = Vector3.zero;

		//PlayerPrefs.SetInt ("CoinCount", theLevelManager.coinCount);
		//PlayerPrefs.SetInt ("PlayerLives", theLevelManager.currentLives);
        

        //theLevelManager.levelMusic.Stop ();
		//theLevelManager.gameOverMusic.Play ();
        //these will require music ^

		yield return new WaitForSeconds (waitToMove);
		movePlayer = true;

		yield return new WaitForSeconds (waitToLoad);
		SceneManager.LoadScene(levelToLoad);
	}
}
