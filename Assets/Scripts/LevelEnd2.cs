using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class LevelEnd2 : MonoBehaviour
{

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

	public float score;
    public float scoretobeatlevel;
	public GameObject LevelEndScreen;
	public Text scoreText;
	public bool levelactive;
	public Text finalscore;

	public bool levelOver;

	// Use this for initialization
	void Start()
	{




	}

    //IEnumerator FindPlayer()
    //{
    //    //yield return new WaitForSeconds(.25f);
    //  
    //
    //}
    // Update is called once per frame

    private void FixedUpdate()
    {
        if (levelactive == true)
        {
			scoreText.text = "score" + (Mathf.RoundToInt(score));
			score += .025f; //this just adds score over time
                            //would need to set score back to 0 when player dies
        }

		finalscore.text = "FINAL SCORE:" + (Mathf.RoundToInt(score));
		//this could also count collectables or even give the person a rank (bronze, silver, gold, etc)

	

		thePlayer = FindObjectOfType<PlayerController>();
		if (movePlayer)
		{
			//thePlayer.myRB2d.velocity = new Vector3 (thePlayer.moveSpeed, thePlayer.myRB2d.velocity.y, 0f);
		}


		if (score >= scoretobeatlevel)
        {
			LevelEnd(); //we call the end of the level when we get the right score


        }
  
    }


	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player")
		{
			//SceneManager.LoadScene(levelToLoad);
			StartCoroutine("LevelEndCo");
		}


		if (tutorial == true)
		{
			PlayerPrefs.SetInt("LvlStart", 1);
		}
	}


    public void LevelEnd()
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

		//yield return new WaitForSeconds(waitToMove);
		//movePlayer = true;

		//yield return new WaitForSeconds(waitToLoad);
		//SceneManager.LoadScene(levelToLoad);

		LevelEndScreen.SetActive(true); //this will turn on our level end screen whihc will
                                        //be a grahpic overlay with buttons that we can use to
                                        //open the next scene, visit the shop or remove ads etc

       // if(Gold > 100)
		{
            //goldstar.enabled = true;
            //have a gold star show up or a silver star etc.

        }

	}
}
