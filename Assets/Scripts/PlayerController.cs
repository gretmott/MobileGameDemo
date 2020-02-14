using UnityEngine;
using System.Collections;
using CnControls;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public float moveSpeed;
	public float jumpSpeed;
	public Rigidbody2D myRigidBody;

    public float fallMultiplier = 2.5f;
    public float lowJumpMulti = 5f;
    public float speed;

    public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask whatIsGround;
	public bool isGrounded;

	private Animator myAnim;

	public Vector3 respawnPosition;
	public LevelManager theLevelManager;

	public GameObject stompBox;

	public float knockBackForce;
	public float knockBackLength;
	public float knockBackCounter;

	public float invincibilityLength;
	private float invincibilityCounter;

	public AudioSource jumpSound;
	public AudioSource hitSound;
    
	public bool canMove;
    public bool redbird;
    public bool shrunk;
    public bool flying;

    public Transform player;
    public Transform target;
    public Transform target2;
    public Transform target3;
    public float step;
    public bool top;
    public bool mid;
    public bool low;
    public float changespeed;
    public bool instant;

    public bool slider;
    public Slider s;
    public float posY;
    public bool joypad;

    public float jumpGrace;
    public float jumpTime;

    public float groundGrace;
    public float groundTime;
    public bool jsound;
    public bool joystick;
    public LeftJoystick leftJoystick;
    public Vector3 leftJoystickInput;


	// Use this for initialization
	void Awake () {
	
		canMove = true;
		myRigidBody = GetComponent<Rigidbody2D>();
		myAnim = GetComponent<Animator>();
		respawnPosition = transform.position;
		theLevelManager = FindObjectOfType<LevelManager>();

        if(joystick == true)
        {
            leftJoystick = FindObjectOfType<LeftJoystick>();
        }
       

    }

    // Update is called once per frame
    void Update()
    {

        step = changespeed * Time.deltaTime;

        //myRigidBody.velocity = new Vector3(moveSpeed, myRigidBody.velocity.y, 0f);
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
        //player.transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime);
        jumpTime -= Time.deltaTime;
        groundTime -= Time.deltaTime;

        if (knockBackCounter > 0)
        {
            knockBackCounter -= Time.deltaTime;

            if (transform.localScale.x > 0)
            {
                myRigidBody.velocity = new Vector3(-knockBackForce, knockBackForce, 0f);
            }
            else
            {
                myRigidBody.velocity = new Vector3(knockBackForce, knockBackForce, 0f);
            }

        }

        if (invincibilityCounter > 0)
        {
            invincibilityCounter -= Time.deltaTime;
        }


        if (invincibilityCounter <= 0)
        {
            theLevelManager.invincible = false;
        }


        myAnim.SetFloat("Speed", Mathf.Abs(myRigidBody.velocity.x));
        myAnim.SetFloat("JumpSpeed", myRigidBody.velocity.y);
        myAnim.SetBool("Grounded", isGrounded);

        if (myRigidBody.velocity.y < 0)
        {
            stompBox.SetActive(true);
        }
        else
        {
            stompBox.SetActive(false);
        }

        if (joystick == true)
        {
            leftJoystickInput = leftJoystick.GetInputDirection();
        }
       

        if (isGrounded == true)
        {
            groundTime = groundGrace;
            jsound = true;
        }
        if (isGrounded == false)
        {
            jsound = false;
        }

        if (knockBackCounter <= 0 && canMove)
        {
            if (redbird == true)
            {
                transform.Translate(Input.acceleration.x, 0, 0);
            }

            if (joystick == true)
            {
                if (leftJoystickInput.x > 0)
                {
                    myRigidBody.velocity = new Vector3(moveSpeed, myRigidBody.velocity.y, 0f);
                    if (shrunk == false)
                    {
                        transform.localScale = new Vector3(1f, 1f, 1f);
                    }

                    else if (shrunk == true)
                    {
                        transform.localScale = new Vector3(.5f, .5f, .5f);
                    }
                }
                if (leftJoystickInput.x < 0)
                {
                    myRigidBody.velocity = new Vector3(-moveSpeed, myRigidBody.velocity.y, 0f);
                    if (shrunk == false)
                    {
                        transform.localScale = new Vector3(-1f, 1f, 1f);
                    }

                    else if (shrunk == true)
                    {
                        transform.localScale = new Vector3(-.5f, .5f, .5f);
                    }

                }
                if (leftJoystickInput.x == 0)
                {
                    myRigidBody.velocity = new Vector3(0f, myRigidBody.velocity.y, 0f);
                }

            }

            if (Input.GetAxisRaw("Horizontal") > 0f )
            {
                //transform.localScale = new Vector3 (1f, 1f, 1f);
                myRigidBody.velocity = new Vector3(moveSpeed, myRigidBody.velocity.y, 0f);
                if (shrunk == false)
                {
                    transform.localScale = new Vector3(1f, 1f, 1f);
                }

                else if (shrunk == true)
                {
                    transform.localScale = new Vector3(.5f, .5f, .5f);
                }

            }
            else if (Input.GetAxisRaw("Horizontal") < 0f)
            {
                //transform.localScale = new Vector3 (-1f, 1f, 1f);
                myRigidBody.velocity = new Vector3(-moveSpeed, myRigidBody.velocity.y, 0f);
                if (shrunk == false)
                {
                    transform.localScale = new Vector3(-1f, 1f, 1f);
                }

                else if (shrunk == true)
                {
                    transform.localScale = new Vector3(-.5f, .5f, .5f);
                }

            }
            //else 
            
            //{
               // myRigidBody.velocity = new Vector3(0f, myRigidBody.velocity.y, 0f);
            //}


            if (Input.GetButtonDown("Jump")) //&& isGrounded) 
            {
                jumpTime = jumpGrace;

                //myRigidBody.velocity = new Vector3 (myRigidBody.velocity.x, jumpSpeed, 0f);
                if (jsound == true)
                {
                    jumpSound.Play();
                    jsound = false;
                }

            }

            if (jumpTime > 0 && groundTime > 0)
            {
                myRigidBody.velocity = new Vector3(myRigidBody.velocity.x, jumpSpeed, 0f);
                //jumpSound.Play ();
            }

            if (joypad == true)
            {
                if (CnInputManager.GetAxisRaw("Horizontal") > 0f)
                {
                    transform.localScale = new Vector3(1f, 1f, 1f);
                    myRigidBody.velocity = new Vector3(moveSpeed, myRigidBody.velocity.y, 0f);
                    if (shrunk == false)
                    {
                        transform.localScale = new Vector3(1f, 1f, 1f);
                    }

                    else if (shrunk == true)
                    {
                        transform.localScale = new Vector3(.5f, .5f, .5f);
                    }

                }
                else if (CnInputManager.GetAxisRaw("Horizontal") < 0f)
                {
                    transform.localScale = new Vector3(-1f, 1f, 1f);
                    myRigidBody.velocity = new Vector3(-moveSpeed, myRigidBody.velocity.y, 0f);
                    if (shrunk == false)
                    {
                        transform.localScale = new Vector3(-1f, 1f, 1f);
                    }

                    else if (shrunk == true)
                    {
                        transform.localScale = new Vector3(-.5f, .5f, .5f);
                    }

                }
                else
                {
                    myRigidBody.velocity = new Vector3(0f, myRigidBody.velocity.y, 0f);
                }


               
            }

            if (CnInputManager.GetButtonDown("Jump")) //&& isGrounded)
            {
                jumpTime = jumpGrace;
                //myRigidBody.velocity = new Vector3(myRigidBody.velocity.x, jumpSpeed, 0f);
                if (jsound == true)
                {
                    jumpSound.Play();
                }
                //jumpSound.Play();
            }

           

        }
    }

        public void Jump()
    {
        //if (isGrounded)
        //{
            jumpTime = jumpGrace;
            //myRigidBody.velocity = new Vector3(myRigidBody.velocity.x, jumpSpeed, 0f);
            //jumpSound.Play();
        //}
    }

    public void Knockback ()
	{
		knockBackCounter = knockBackLength;
		invincibilityCounter = invincibilityLength;
		theLevelManager.invincible = true;
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


    void OnCollisionEnter2D (Collision2D other)
	{
        if (other.gameObject.tag == "MovingPlatform")
        {
            transform.parent = other.transform;
            //myRigidBody.GetComponent<CircleCollider2D>().enabled = false;
        }

    }

	void OnCollisionExit2D (Collision2D other)
	{
        if (other.gameObject.tag == "MovingPlatform")
        {
            transform.parent = null;
            //myRigidBody.GetComponent<CircleCollider2D>().enabled = true;
        }
    }

}