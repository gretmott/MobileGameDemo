using UnityEngine;
using System.Collections;
using CnControls;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	
	public Rigidbody2D myRB2d;
    private Animator myAnim;
    public float jetpower;
    public bool up;
    public GameObject cannonball;

    public int gold;
    public Text goldText;

	public Vector3 respawnPosition;
	public LevelManager theLevelManager;


	public float invincibilityLength;
	private float invincibilityCounter;
    public bool canMove;


	


	// Use this for initialization
	void Awake () {
	
	
		myAnim = GetComponent<Animator>();
		respawnPosition = transform.position;
        theLevelManager = FindObjectOfType<LevelManager>();
       

    }

    private void Start()
    {
        //gold = PlayerPrefs.GetInt("Gold");
    }

    // Update is called once per frame
    void Update()
    {

        goldText.text = "Gold:" + gold;


       // PlayerPrefs.SetInt("Gold", gold);

       // if(gold >= 10)
        //{
            //start end of level celebrations
        //}


        if(up == true)
        {
            myRB2d.velocity = new Vector2(0, jetpower);
        }

        else
        {
            myRB2d.velocity = new Vector2(0, 0);
        }

        if (CnInputManager.GetButtonDown ("Shoot"))
       {
           MF_AutoPool.Spawn(cannonball, transform.position, transform.rotation);
       }

        if (invincibilityCounter > 0)
        {
            invincibilityCounter -= Time.deltaTime;
        }


        if (invincibilityCounter <= 0)
        {
            theLevelManager.invincible = false;
        }


        myAnim.SetFloat("Speed", Mathf.Abs(myRB2d.velocity.x));
        myAnim.SetFloat("JumpSpeed", myRB2d.velocity.y);
        




    }

    public void poweron()
    {
        up = true;
    }
    public void poweroff()
    {
        up = false;
    }



	void OnTriggerEnter2D (Collider2D other)
	{

		if (other.tag == "Checkpoint") 
		{
			respawnPosition = other.transform.position;
		}

		if (other.tag == "KillPlane") 
		{
			//gameObject.SetActive (false);
			//transform.position = respawnPosition;
			if (theLevelManager.respawning == false) {
				theLevelManager.Respawn ();
			}
		}

        

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        
    }


    

}