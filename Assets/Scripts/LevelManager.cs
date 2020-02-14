using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public float waitToRespawn;
    public PlayerController thePlayer;
    //public PlayerController thePlayer2;
    //public Transform p2respawn;

    public SpriteRenderer sr;
    //public SpriteRenderer sr2;
    public Rigidbody2D rb2D;
    //public Rigidbody2D rb2D2;

    //public int coinCount;
    //
	//public float PlayerX;
	//public float PlayerY;
	//public float PlayerZ;

	public GameObject DieBurst;

	//public Text coinText;

	public Image heart1;
	public Image heart2;
	public Image heart3;

	public Sprite heartFull;
	public Sprite heartHalf;
	public Sprite heartEmpty;

	public int maxHealth;
	public int healthCount;

	public bool respawning;
	public ResetOnRespawn[] objectsToReset;

	public bool invincible;

	//public int currentLives;
	//public int startingLives;
	//public Text livesText;
    //
	//public GameObject gameOverScreen;
	//public AudioSource coinSound;
	public AudioSource levelMusic;
	public AudioSource gameOverMusic;
    //
	//public GameObject pauseScreen;


    // Use this for initialization

    void Start () {

		//pauseScreen.SetActive(true);
        
        //thePlayer = FindObjectOfType<PlayerController> ();
        //sr = GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>();

        StartCoroutine("FindPlayer");
        
		objectsToReset = FindObjectsOfType<ResetOnRespawn> ();

		//if (PlayerPrefs.HasKey ("CoinCount")) 
		//{
		//	coinCount = PlayerPrefs.GetInt ("CoinCount");
		//}

		//coinText.text = "Stars: " + coinCount;

		//if (PlayerPrefs.HasKey ("PlayerLives")) 
		//{
		//	currentLives = PlayerPrefs.GetInt ("PlayerLives");
		//} else 
		//{
		//	currentLives = startingLives;
		//}
        //
		//livesText.text = "Lives x" + currentLives;
	
	}

    IEnumerator FindPlayer()
    {
        yield return new WaitForSeconds(.25f);
        thePlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        sr = GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>();
        rb2D = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        rb2D.simulated = true;
    }

    // Update is called once per frame
    void Update () {

		if (healthCount <= 0 && !respawning) 
		{
			Respawn ();
			respawning = true;
		}
	
	}

	public void Respawn ()
	{
		//currentLives -= 1;
		//livesText.text = "Lives x" + currentLives;
		respawning = true;

		//if (currentLives > 0) {
			StartCoroutine ("RespawnCo");
		//} else 
		//{
		//	thePlayer.enabled = false;
        //   // thePlayer2.enabled = false;
        //    sr.enabled = false;
        //   // sr2.enabled = false;
        //    rb2D.simulated = false;
        //   // rb2D2.simulated = false;
        //    gameOverScreen.SetActive (true);
		//	pauseScreen.SetActive (false);
		//	levelMusic.Stop ();
		//	gameOverMusic.Play ();
		//	//levelMusic.volume = levelMusic.volume / 2f;
		//}
	}

	public IEnumerator RespawnCo()
	{
        thePlayer.enabled = false;
        sr.enabled = false;
        rb2D.simulated = false;
       // thePlayer2.enabled = false;
       // sr2.enabled = false;
       // rb2D2.simulated = false;
        Instantiate (DieBurst, thePlayer.transform.position, thePlayer.transform.rotation);
       // Instantiate(DieBurst, thePlayer2.transform.position, thePlayer2.transform.rotation);

        yield return new WaitForSeconds (waitToRespawn);

		healthCount = maxHealth;
		respawning = false;
		UpdateHeartMeter ();
		//coinCount = 0;
		//coinText.text = "Stars:" + coinCount;
		thePlayer.transform.position = thePlayer.respawnPosition;
       // thePlayer2.transform.position = p2respawn.transform.position;

        thePlayer.enabled = true;
        sr.enabled = true;
        rb2D.simulated = true;
        thePlayer.knockBackCounter = 0;
      
      //  thePlayer2.enabled = true;
      //  sr2.enabled = true;
      //  rb2D2.simulated = true;
      //  thePlayer2.knockBackCounter = 0;

        for (int i = 0; i < objectsToReset.Length; i++) 
		{
			objectsToReset [i].gameObject.SetActive (true);
			objectsToReset [i].ResetObject ();
		}
	}

	public void AddCoins (int coinsToAdd)
	{
		//coinCount += coinsToAdd;
		//coinText.text = "Stars: " + coinCount;
		//coinSound.Play ();
	}

	public void HurtPlayer (int damageToTake)
	{
		if (!invincible) 
		{
			healthCount -= damageToTake;
			UpdateHeartMeter ();
			thePlayer.Knockback ();
			thePlayer.hitSound.Play ();
		}
	}

	public void GiveHealth(int healthToGive)
	{
		healthCount += healthToGive;
		
			if (healthCount > maxHealth)
			{
				healthCount = maxHealth;
			}

		UpdateHeartMeter ();
		//coinSound.Play ();
		
	}

	public void UpdateHeartMeter()
	{
		switch (healthCount) 
		{
		case 6:
			heart1.sprite = heartFull;
			heart2.sprite = heartFull;
			heart3.sprite = heartFull;
			return;

		case 5:
			heart1.sprite = heartFull;
			heart2.sprite = heartFull;
			heart3.sprite = heartHalf;
			return;

		case 4:
			heart1.sprite = heartFull;
			heart2.sprite = heartFull;
			heart3.sprite = heartEmpty;
			return;


		case 3:
			heart1.sprite = heartFull;
			heart2.sprite = heartHalf;
			heart3.sprite = heartEmpty;
			return;

		case 2:
			heart1.sprite = heartFull;
			heart2.sprite = heartEmpty;
			heart3.sprite = heartEmpty;
			return;

		case 1:
			heart1.sprite = heartHalf;
			heart2.sprite = heartEmpty;
			heart3.sprite = heartEmpty;
			return;

		case 0:
			heart1.sprite = heartEmpty;
			heart2.sprite = heartEmpty;
			heart3.sprite = heartEmpty;
			return;

		default:
			heart1.sprite = heartEmpty;
			heart2.sprite = heartEmpty;
			heart3.sprite = heartEmpty;
			return;


		}
	}

	public void AddLives(int livesToAdd)
	{
		//currentLives += livesToAdd;
		//livesText.text = "Lives x" + currentLives;
		//coinSound.Play ();
	}




}
